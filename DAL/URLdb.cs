using BOL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class UrlDb
    {
        private LinkHubDbEntities db;
        public UrlDb()
        {
            db = new LinkHubDbEntities();
        }
        public IEnumerable<tbl_Url> GetAll()
        {
            return db.tbl_Url.ToList();
        }
        public tbl_Url GetById(int id)
        {
            return db.tbl_Url.First(u => u.UrlId == id);//koristis First jer je brzi od single, jer se odmah zaustavi kad nadje prvog
            //u primjeru koristi Find(id) - Find should be as fast as First, but is less portable as it will only work on lists. 
        }
        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            Save();
        }
        public void Delete(int id)
        {
            var url = db.tbl_Url.First(u => u.UrlId == id);
            db.tbl_Url.Remove(url);
        }
        public void Update(tbl_Url url)
        {
            db.Entry(url).State = EntityState.Modified;
            //moze i da ga nadjes u bazi, promijenis propertije i onda Save(), ali ovo je jednostavniej
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
