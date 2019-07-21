using Programing.Dal;
using ProgramingWebApi.Attributes;
using ProgramingWebApi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProgramingWebApi.Controllers
{
    //Hatanın neden kaynaklandıgının bilgisini verir
    //webapi config dosyasına eklersen tum proje icin gecerli olur 
    [ApiExceptionAttribute]
    public class LanguagesController : ApiController
    {
        LanguagesDal languagesDal = new LanguagesDal();

        //Servislerimizde donen nesne hakkında bilgi verir.
        [ResponseType(typeof(IEnumerable<Language>))]

        /* public HttpResponseMessage Get()
         {
             var languages = languagesDal.GetAllLanguages();
             return Request.CreateResponse(HttpStatusCode.OK,languages);
         } */

        //aynı işi yapar, kısa yolu
        //kullanıcı kontrol eder herkese acık degıl
        [ApiAuthorize(Roles = "Admin")]
        public IHttpActionResult Get()
        {
            var languages = languagesDal.GetAllLanguages();
            return Ok(languages);
        }

        /*public HttpResponseMessage Get(int id)
        {
            var language = languagesDal.GetLanguageById(id);
            if (language == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"Böyle bir kayıt bulunamadı.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, language);
        }*/

        //aynı işi yapar, kısa yolu
        //donen tip hakkında bilgi verir
        [ResponseType(typeof(Language))]
        [ApiAuthorize (Roles="Admin,User")]
        //kendi yazdıgım Authorize attribute
        public IHttpActionResult Get(int id)
        {
            var language = languagesDal.GetLanguageById(id);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);

        }

        [ResponseType(typeof(Language))]
        [ApiAuthorize(Roles = "Admin")]
        public HttpResponseMessage Post(Language language)
        {
            //ModelState: Model belirlediğim kurallara uygunsa(Languge de) if içinde yap işlemi 
            //değilse else ile hata mesajı dondur.
            if (ModelState.IsValid)
            {
                var createdLanguage = languagesDal.CreateLanguage(language);
                return Request.CreateResponse(HttpStatusCode.Created, createdLanguage);
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            }

        }
        /*
        public HttpResponseMessage Put (int id, Language language)
        {
            //id ye ait kayıt yok ise
            if (languagesDal.IsThereAnyLanguage(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı.");
            }

            //language modeli dogrulanmadıysa, tanımladıgımız kurallara uyulmadıysa
            else if (ModelState.IsValid == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, languagesDal.UpdateLanguage(id, language));
            }

        }*/

        //aynı işi yapar, kısa yolu
        [ResponseType(typeof(Language))]
        [ApiAuthorize(Roles = "Admin")]
        public IHttpActionResult Put(int id, Language language)
        {
            if (languagesDal.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
            }

            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            else
            {
                return Ok(languagesDal.UpdateLanguage(id, language));
            }

        }

        /*
        public HttpResponseMessage Delete(int id)
        {
            if (languagesDal.IsThereAnyLanguage(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }

            else
            {
                languagesDal.DeleteLanguage(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            
        }*/


        //aynı işi yapar, kısa yolu
        [ApiAuthorize(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            if (languagesDal.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
            }

            else
            {
                languagesDal.DeleteLanguage(id);
                return Ok();
            }
        }
    }

}
