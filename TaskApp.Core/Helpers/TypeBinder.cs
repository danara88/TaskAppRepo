using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace TaskApp.Core.Helpers
{
    /// <summary>
    /// Custom ModelBinder to allow any T object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var propertyName = bindingContext.ModelName;
            var propertyValue = bindingContext.ValueProvider.GetValue(propertyName);

            if (propertyValue == ValueProviderResult.None) return Task.CompletedTask;

            try
            {
                var deserializeValue = JsonConvert.DeserializeObject<T>(propertyName);
                bindingContext.Result = ModelBindingResult.Success(deserializeValue);
            }
            catch (System.Exception)
            {
                bindingContext.ModelState.TryAddModelError(propertyName, "The value es not valid");
            }

            return Task.CompletedTask;
        }
    }
}
