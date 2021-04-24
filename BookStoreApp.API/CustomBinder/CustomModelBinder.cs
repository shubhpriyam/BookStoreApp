using Microsoft.AspNetCore.Mvc.ModelBinding;
using BookStoreApp.Contracts.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.BookStore.CustomBinder
{
    public class CustomModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            string valueFromBody = string.Empty;
            using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody = await sr.ReadToEndAsync().ConfigureAwait(false);
            }
            var bodyContent = JObject.Parse(valueFromBody);
            //var result = JsonConvert.DeserializeObject<BookModel>(valueFromBody);
            //result.Title = Convert.ToString(((JValue)bodyContent["booktitle"]).Value);
            //result.Author = Convert.ToString(((JValue)bodyContent["bookauthor"]).Value);
            //result.Imageurl = Convert.ToString(((JValue)bodyContent["bookurl"]).Value);
            //result.Description = Convert.ToString(((JValue)bodyContent["bookdescription"]).Value);

            var result = new BookModel()
            {
                Title = Convert.ToString(((JValue)bodyContent["booktitle"]).Value),
                Author = Convert.ToString(((JValue)bodyContent["bookauthor"]).Value),
                Imageurl =Convert.ToString(((JValue)bodyContent["bookurl"]).Value),
                Description = Convert.ToString(((JValue)bodyContent["bookdescription"]).Value)
            };
            
            bindingContext.Result = ModelBindingResult.Success(result);
        }
    }
}
