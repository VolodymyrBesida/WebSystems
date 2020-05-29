using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredData
{
    public static  class Storage
    {
        public class Query
        {
            [Key]
            public int Id { get; set; }
            public string Question { get; set; }
            public int Answear { get; set; }
            public Query() { }
            public Query(string q,int a)
            {
                Question = q;
                Answear = a;
            }
        }

        public class QueryContext: DbContext
        {
            public QueryContext()
                :base("DbConnection")
            { }

            public DbSet<Query> Queries { get; set; }
        }

        public static void toStore(string question,int answear)
        {
            using (QueryContext db  = new QueryContext())
            {
                Query ans = new Query(question, answear);
                db.Queries.Add(ans);
                db.SaveChanges();
            }
        }

        public static List<Query> getStorage()
        {
            List<Query> data = new List<Query>();

            using (QueryContext db = new QueryContext())
            {
                var result = db.Queries.OrderByDescending(x => x.Id).ToList();
                      result = result.GetRange(0, 5);

                foreach (var s in result) { data.Add(s); }
            }
            return data;
        }
    }
}
