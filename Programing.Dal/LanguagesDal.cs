using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing.Dal
{
    public class LanguagesDal:BaseDal
    {
        //ProgrammingDbEntities dbEntities = new ProgrammingDbEntities();
        //BaseDal da oluşturulup miras alındı gerek kalmadı.
        public IEnumerable<Language> GetAllLanguages()
        {
            return dbEntities.Languages;
        }

        public Language GetLanguageById(int id)
        {
            return dbEntities.Languages.Find(id);
        }

        public Language CreateLanguage(Language language)
        {
            dbEntities.Languages.Add(language);
            dbEntities.SaveChanges();
            return language;
        }

        public Language UpdateLanguage(int id, Language language)
        {
            dbEntities.Entry(language).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();
            return language;
        }

        public void DeleteLanguage(int id)
        {
            dbEntities.Languages.Remove(dbEntities.Languages.Find(id));
            dbEntities.SaveChanges();
        }

        public bool IsThereAnyLanguage(int id)
        {
            return dbEntities.Languages.Any(x => x.ID == id);
        }
    }
}
