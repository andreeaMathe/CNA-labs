using MongoDB.Driver;
using QuizService.DataAccess.MongoDB.ModelDb;
using QuizService.DataAccess.MongoDB.Settings;
using QuizService.DataAccess.Repositories;
using QuizService.Exceptions;
using QuizService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizService.DataAccess.MongoDB.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        public const string AnswersCollectionName = "Answers";
        private readonly QuizDatabase quizDatabase;

        public AnswerRepository(IQuizDatabaseSettings settings)
        {
            quizDatabase = new QuizDatabase(settings);
        }

        private IMongoCollection<AnswerDb> Answers => quizDatabase.GetCollection<AnswerDb>(AnswersCollectionName);

        public async Task Add(Answer entity)
        {
            try
            {
                await Answers.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }

        public async Task<List<Answer>> GetAll()
        {
            try
            {
                IAsyncCursor<AnswerDb> answersDb = await Answers.FindAsync(answer => true);

                return await Task.FromResult(answersDb
                    .ToList()
                    .Select(x => (Answer)x)
                    .ToList());
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }


        public async Task<Answer> GetAnswerByContent(string content)
        {
            try
            {
                IAsyncCursor<AnswerDb> answerDb = await Answers.FindAsync(x => x.Content == content);

                Answer answer = answerDb.FirstOrDefault();

                if (answer == null)
                    throw new ArgumentNullException(nameof(answer));

                return await Task.FromResult(answer);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }

        public async Task<Answer> GetAnswerById(int id)
        {
            try
            {
                IAsyncCursor<AnswerDb> answerDb = await Answers.FindAsync(x => x.Id == id);

                Answer answer = answerDb.FirstOrDefault();

                if (answer == null)
                    throw new ArgumentNullException(nameof(answer));

                return await Task.FromResult(answer);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }

        public async Task Update(Answer answer)
        {
            try
            {
                await Answers.ReplaceOneAsync(x => x.Id == answer.Id, answer);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await Answers.DeleteOneAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }
    }
}
