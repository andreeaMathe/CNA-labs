using MongoDB.Bson;
using MongoDB.Driver;
using QuizService.DataAccess.MongoDB.ModelDb;
using QuizService.DataAccess.MongoDB.Repositories;
using QuizService.DataAccess.MongoDB.Settings;
using QuizService.Model;
using System.Collections.Generic;
using System.Linq;

namespace QuizService.DataAccess.MongoDB
{
    internal class QuizDatabase
    {
        private readonly IMongoDatabase mongoDatabase;

        public QuizDatabase(IQuizDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);

            mongoDatabase = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            EnsureCollection(collectionName);
            return mongoDatabase.GetCollection<T>(collectionName);
        }

        private void EnsureCollection(string collectionName)
        {
            bool collectionExists = CollectionExists(mongoDatabase, collectionName);

            if (!collectionExists)
            {
                mongoDatabase.CreateCollection(collectionName, new CreateCollectionOptions());

                if (collectionName == QuestionRepository.QuestionsCollectionName)
                {
                    var a1 = new Answer() { Id = 1, Content = "42" };
                    var a2 = new Answer() { Id = 1, Content = "43" };
                    var a3 = new Answer() { Id = 1, Content = "both" };
                    var a4 = new Answer() { Id = 1, Content = "none of the above" };

                    var q = new Question
                    {
                        Id = 1,
                        Content = "What's the meaning of life?",
                        PossibleAnswers = new List<Answer>() { a1, a2, a3, a4},
                        CorrectAnswers = new List<Answer>() { a1 },
                    };

                    mongoDatabase.GetCollection<QuestionDb>(QuestionRepository.QuestionsCollectionName).InsertOne(q);
                }
            }
        }

        private static bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            BsonDocument filter = new BsonDocument("name", collectionName);
            ListCollectionNamesOptions options = new ListCollectionNamesOptions { Filter = filter };

            return database.ListCollectionNames(options).Any();
        }
    }
}
