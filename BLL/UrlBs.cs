using BOL;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class UrlBs
    {
        private UrlDb objDb;
        public UrlBs()
        {
            objDb = new UrlDb();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return objDb.GetAll();
        }
        public tbl_Url GetById(int id)
        {
            return objDb.GetById(id); 
        }
        public void Insert(tbl_Url url)
        {
            objDb.Insert(url);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
        public void Update(tbl_Url url)
        {
            objDb.Update(url);
        }
        //ovo nema smisla da postoji
        //public void Save()
        //{
        //    objDb.Save();
        //}
    }
}
