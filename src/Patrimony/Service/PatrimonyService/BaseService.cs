using Newtonsoft.Json;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract
{
    public abstract class BaseService<TEntity, G> : IGenericService<TEntity, G> where TEntity : BaseEntity, new()
    {
        protected readonly IGenericRepository<TEntity, G> repository;

        public BaseService(IGenericRepository<TEntity, G> repository)
        {
            this.repository = repository;
        }

        public BaseService()
        {

        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await repository.Create(obj);

            return obj;
        }

        public async Task Delete(long id)
        {
            await repository.Delete(id);
        }

        public Task<TEntity> Get(long id)
        {
            return repository.Get(id);
        }

        public Task<QueryResult<TEntity>> Get(G filter)
        {
            return repository.Get(filter);
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            await repository.Update(obj);
            return obj;
        }
        public async Task Patch(long id, TEntity patch)
        {
            var obj = await repository.Get(id);

            Patch(obj, patch);
        }
        public void Patch(TEntity obj, TEntity patch)
        {
            foreach (PropertyInfo prop in patch.GetType().GetProperties())
            {
                if (prop.GetValue(patch) != null)
                    obj.GetType().GetProperty(prop.Name).SetValue(obj, prop.GetValue(patch));
            }

            repository.Update(obj);
        }
        public async Task Patch(long id, ExpandoObject patch)
        {
            var obj = repository.GetAsNoTrackingId(id);

            await Patch(obj, patch);
        }
        public async Task Patch(TEntity obj, ExpandoObject patch)
        {
            IDictionary<string, object> dict = patch;

            Patch(obj, dict);

           await Update(obj);
        }
        public void Patch(TEntity obj, IDictionary<string, object> dict)
        {
            var flags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

            if (dict.ContainsKey("id"))
                dict.Remove("id");

            foreach (var prop in dict.Keys)
            {
                if (prop != null)
                {
                    var property = obj.GetType().GetProperty(prop, flags);

                    if (property != null)
                    {
                        Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                        if (property.CanWrite)
                        {
                            if (propertyType.IsEnum)
                            {
                                property.SetValue(obj, dict[prop] != null ? Enum.Parse(propertyType, dict[prop].ToString()) : null);
                            }
                            else if (propertyType == typeof(int))
                            {
                                property.SetValue(obj, dict[prop] != null && dict[prop].ToString() != "" ? int.Parse(dict[prop].ToString()) : null);
                            }
                            else if (propertyType == typeof(long))
                            {
                                property.SetValue(obj, dict[prop] != null && dict[prop].ToString() != "" ? long.Parse(dict[prop].ToString()) : null);
                            }
                            else if (propertyType == typeof(decimal))
                            {
                                property.SetValue(obj, dict[prop] != null && dict[prop].ToString() != "" ? decimal.Parse(dict[prop].ToString()) : null);
                            }
                            else if (propertyType == typeof(double))
                            {
                                property.SetValue(obj, dict[prop] != null && dict[prop].ToString() != "" ? double.Parse(dict[prop].ToString()) : null);
                            }
                            else if (propertyType.IsClass && !property.PropertyType.FullName.StartsWith("System."))
                            {
                                var IdEntity = JsonConvert.DeserializeObject<BaseEntity>(JsonConvert.SerializeObject((ExpandoObject)dict[prop]));

                                var propertyFK = obj.GetType().GetProperty(prop + "Id", flags);

                                if (propertyFK != null)
                                    propertyFK.SetValue(obj, IdEntity.Id);
                            }
                            else
                                property.SetValue(obj, dict[prop]);
                        }
                    }
                }
            }
        }

        public TEntity GetAsnotrack(long id)
        {
            return repository.GetAsNoTrackingId(id);
        }

        //public void AddList(List<T> list)
        //{
        //    repository.AddList(list);
        //}
        //public void RemoveList(List<T> list)
        //{
        //    repository.RemoveList(list);
        //}
        //public void UpdateList(List<T> list)
        //{
        //    repository.UpdateList(list);
        //}
        //protected void Notificar(ValidationResult validationResult)
        //{
        //    foreach (var error in validationResult.Errors)
        //    {
        //        Notificar(error.ErrorMessage);
        //    }
        //}

        //protected void Notificar(string mensagem)
        //{
        //    _notificador.Handle(new Notificacao(mensagem));
        //}

        //protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        //{
        //    var validator = validacao.Validate(entidade);

        //    if (validator.IsValid) return true;

        //    Notificar(validator);

        //    return false;
        //}
    }
}
