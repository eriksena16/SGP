//using Microsoft.EntityFrameworkCore;
//using SGP.Contract.Service.PatrimonyContract;
//using SGP.Model.Entity;
//using SGP.Patrimony.Repository.PatrimonyRepository;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SGP.Patrimony.Service.PatrimonyService
//{
//    public class ClassificacaoDeAtivosService : IClassificacaoDeAtivosService
//    {
//        private readonly SGPContext context;
//        public ClassificacaoDeAtivosService(SGPContext context) => this.context = context;

//        public async Task<ClassificacaoDeAtivos> Create(ClassificacaoDeAtivos obj)
//        {
//            context.Add(obj);
//            await context.SaveChangesAsync();

//            return obj;
//        }

//        public async Task<ClassificacaoDeAtivos> Delete(long? id)
//        {
//            ClassificacaoDeAtivos assetClassification = new ClassificacaoDeAtivos();

//            return await this.Get(assetClassification.Id);
//        }

//        public async Task<ClassificacaoDeAtivos> DeleteConfirmed(long id)
//        {
//            ClassificacaoDeAtivos assetClassification = await context.Classificacao.FindAsync(id);

//            context.Classificacao.Remove(assetClassification);
//            await context.SaveChangesAsync();

//            return assetClassification;
//        }

//        public async Task<ClassificacaoDeAtivos> Get(long? id)
//        {
//            ClassificacaoDeAtivos assetClassification = await context.Classificacao
//               .FirstOrDefaultAsync(m => m.Id == id);

//            return assetClassification;
//        }

//        public async Task<bool> Exists(long id)
//        {
//            return await Task.FromResult(context.Classificacao.Any(e => e.Id == id));
//        }

//        public async Task<List<ClassificacaoDeAtivos>> GetAll()
//        {
//            List<ClassificacaoDeAtivos> assetClassification = await context.Classificacao.ToListAsync();

//            return assetClassification;
//        }

//        public async Task<ClassificacaoDeAtivos> GetUpdate(long id)
//        {
//            ClassificacaoDeAtivos assetClassification = await context.Classificacao.FindAsync(id);

//            return assetClassification;
//        }

//        public async Task<ClassificacaoDeAtivos> Update(long id, ClassificacaoDeAtivos obj)
//        {
//            context.Update(obj);
//            await context.SaveChangesAsync();

//            return obj;
//        }
//    }
//}
