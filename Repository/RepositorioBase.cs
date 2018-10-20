using Entities.Contexts;
using Entities.Models;
using Entities.Models.Catalogos;
using Entities.Models.Extras;
using Entities.Models.Masterfiles;
using Entities.Models.Paquetes;
using Entities.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly DbContext Context;
        private DbSet<T> _entities;

        public RepositorioBase(DbContext context)
        {
            this.Context = context;
            this._entities = Context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await this._entities.AddAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await this._entities.AddRangeAsync(entities);

            return entities;
        }

        public async Task<IEnumerable<T>> FindAsyc(Expression<Func<T, bool>> predicado)
        {
            return await _entities.Where(predicado).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsyc()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            this._entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this._entities.RemoveRange(entities);
        }

        public T Update(T entity)
        {
            this._entities.Update(entity);


            return entity;
        }
    }

    // 
    public class RepositorioAgenda : RepositorioBase<Agenda>, IRepositorioAgenda
    {
        public RepositorioAgenda(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioHotel : RepositorioBase<Hotel>, IRepositorioHotel
    {
        public RepositorioHotel(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    //public class RepositorioEjecutivo : RepositorioBase<Ejecutivo>, IRepositorioEjecutivo
    //{
    //    public RepositorioEjecutivo(AppDbContext contexto) : base(contexto)
    //    {
    //    }

    //    public AppDbContext appDbContext
    //    {
    //        get { return Context as AppDbContext; }
    //    }
    //}


    //public class RepositorioCoordinador : RepositorioBase<Coordinador>, IRepositorioCoordinador
    //{
    //    public RepositorioCoordinador(AppDbContext contexto) : base(contexto)
    //    {
    //    }

    //    public AppDbContext appDbContext
    //    {
    //        get { return Context as AppDbContext; }
    //    }
    //}


    public class RepositorioUsuarioHotel : RepositorioBase<UsuarioHotel>, IRepositorioUsarioHotel
    {
        public RepositorioUsuarioHotel(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioLugarCena : RepositorioBase<LugarCena>, IRepositorioLugarCena
    {
        public RepositorioLugarCena(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioLugarCeremonia : RepositorioBase<LugarCeremonia>, IRepositorioLugarCeremonia
    {
        public RepositorioLugarCeremonia(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioBackUp : RepositorioBase<BackUp>, IRepositorioBackUp
    {
        public RepositorioBackUp(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioHoras : RepositorioBase<Horas>, IRepositorioHoras
    {
        public RepositorioHoras(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioTipoCeremonia : RepositorioBase<TipoCeremonia>, IRepositorioTipoCeremonia
    {
        public RepositorioTipoCeremonia(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioAgencia : RepositorioBase<Agencia>, IRepositorioAgencia
    {
        public RepositorioAgencia(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioDiasBloqueados : RepositorioBase<DiasBloqueados>, IRepositorioDiasBloqueados
    {
        public RepositorioDiasBloqueados(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioComentario : RepositorioBase<Comentario>, IRepositorioComentario
    {
        public RepositorioComentario(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
    public class RepositorioHistorial : RepositorioBase<Historial>, IRepositorioHistorial
    {
        public RepositorioHistorial(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioMasterFile : RepositorioBase<MasterFile>, IRepositorioMasterFile
    {
        public RepositorioMasterFile(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioMasterFileContent : RepositorioBase<MasterFileContent>, IRepositorioMasterFileContent
    {
        public RepositorioMasterFileContent(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioPaquete : RepositorioBase<Paquete>, IRepositorioPaquete
    {
        public RepositorioPaquete(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }




    public class RepositorioServicio : RepositorioBase<Servicio>, IRepositorioServicio
    {
        public RepositorioServicio(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioPaqueteServicio : RepositorioBase<PaqueteServicio>, IRepositorioPaqueteServicio
    {
        public RepositorioPaqueteServicio(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioCategoriaServicio : RepositorioBase<CategoriaServicio>, IRepositorioCategoriaServicio
    {
        public RepositorioCategoriaServicio(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }



    public class RepositorioRole : RepositorioBase<Role>, IRepositorioRole
    {
        public RepositorioRole(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioDivisa : RepositorioBase<Divisa>, IRepositorioDivisa
    {
        public RepositorioDivisa(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


}
