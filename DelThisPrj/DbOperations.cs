using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelThisPrj
{
    public static class DbOperations
    {
        /// <summary>
        /// Add on db new word with exists count
        /// </summary>
        /// <param name="word"></param>
        /// <param name="exists"></param>
        public async static void Add(string word, int exists)
        {
            using (var db = new DbConnection())
            {
                var model = new Model() { Word = word, Exists = exists };
                db.Set<Model>().Add(model);
                await db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Find word and sum new exists with old num
        /// </summary>
        /// <param name="word"></param>
        /// <param name="exists"></param>
        public async static void Update(string word, int exists)
        {
            using (var db = new DbConnection())
            {
                var model = db.Set<Model>().FirstOrDefault(x => x.Word == word);
                if (model == null)
                {
                    Add(word, exists);
                    return;
                }
                model.Exists += exists;
                await db.SaveChangesAsync();
            }
        }
    }
}
