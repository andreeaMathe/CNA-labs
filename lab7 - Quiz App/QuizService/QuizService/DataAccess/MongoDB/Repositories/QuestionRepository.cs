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
    public class QuestionRepository : IQuestionRepository
    {
        public const string QuestionsCollectionName = "Questions";
        private readonly QuizDatabase quizDatabase;

        public QuestionRepository(IQuizDatabaseSettings settings)
        {
            quizDatabase = new QuizDatabase(settings);
        }

        private IMongoCollection<QuestionDb> Questions => quizDatabase.GetCollection<QuestionDb>(QuestionsCollectionName);

        public async Task Add(Question entity)
        {
            try
            {
                await Questions.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }

        public async Task<List<Question>> GetAll()
        {
            try
            {
                IAsyncCursor<QuestionDb> questionsDb = await Questions.FindAsync(question => true);

                return await Task.FromResult(questionsDb
                    .ToList()
                    .Select(x => (Question)x)
                    .ToList());
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }


        public async Task<Question> GetQuestionByContent(string content)
        {
            try
            {
                IAsyncCursor<QuestionDb> questionDb = await Questions.FindAsync(x => x.Content == content);

                Question question = questionDb.FirstOrDefault();

                if (question == null)
                    throw new ArgumentNullException(nameof(question));

                return await Task.FromResult(question);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }

        public async Task<Question> GetQuestionById(int id)
        {
            try
            {
                IAsyncCursor<QuestionDb> questionDb = await Questions.FindAsync(x => x.Id == id);

                Question question = questionDb.FirstOrDefault();

                if (question == null)
                    throw new ArgumentNullException(nameof(question));

                return await Task.FromResult(question);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }

        public async Task Update(Question question)
        {
            try
            {
                await Questions.ReplaceOneAsync(x => x.Id == question.Id, question);
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
                await Questions.DeleteOneAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new QuizDatabaseException(ex);
            }
        }
    }
}
