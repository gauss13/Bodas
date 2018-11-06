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

        public async Task<IEnumerable<Agenda>> GetFechasByMes(int hotel, int anio, int mes)
        {

            //     start  : '2018-10-09T12:30:00',
            //return await appDbContext.Agendas.Where(x => x.FechaBoda.Value.Year == anio && x.FechaBoda.Value.Month == mes)
            //    .Select(f => new AgendaFechas { idagenda = f.Id, start = $"{f.FechaBoda.Value.ToString("yyyy-MM-dd")}T{f.HoraBoda}", end = null, estatus = f.EstadoAgendaId, title = "", url = "" }).ToListAsync();
            //&& x.Activo == true
            return await appDbContext.Agendas.Where(x => x.FechaBoda.Value.Year == anio && x.FechaBoda.Value.Month == mes && x.HotelId == hotel )
              .Select(a => new Agenda { Id = a.Id, FechaBoda = a.FechaBoda, HoraBoda = a.HoraBoda, EstadoAgendaId = a.EstadoAgendaId }).ToListAsync();


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


        public async Task<IEnumerable<LugarCena>> GetLugarCenaConHotelAsync()
        {
            //return await appDbContext.LugaresCena.Include(x => x.Hotel ).ThenInclude(y => y.Nombre).ToListAsync();
            return await appDbContext.LugaresCena.Include(h => h.Hotel)
                .Where(l => l.Activo == true)
                .Select(h => new LugarCena { Id = h.Id, Lugar = h.Lugar, HotelId = h.HotelId, Hotel = h.Hotel, Activo = h.Activo })
                .ToListAsync();
        }

        public async Task<LugarCena> GetLugarCenaConHotelByIdAsync(int id)
        {
            //return await Context.Set<T>().FindAsync(id);

            return await appDbContext.LugaresCena.Include(x => x.Hotel)
                .Where(l => l.Id == id && l.Activo == true)
                .Select(h => new LugarCena { Id = h.Id, Lugar = h.Lugar, HotelId = h.HotelId, Hotel = h.Hotel, Activo = h.Activo })
                .FirstOrDefaultAsync();
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


    public class RepositorioTtoo : RepositorioBase<Ttoo>, IRepositorioTtoo
    {
        public RepositorioTtoo(AppDbContext contexto) : base(contexto)
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

        public async Task<IEnumerable<DiasBloqueados>> GetFechasByMes(int hotel, int anio, int mes)
        {
            return await appDbContext.DiasBloquedo.Where(x => x.Fecha.Year == anio && x.Fecha.Month == mes && x.HotelId == hotel)
                .ToListAsync();

            //return await appDbContext.Agendas.Where(x => x.FechaBoda.Value.Year == anio && x.FechaBoda.Value.Month == mes && x.HotelId == hotel)
            // .Select(a => new Agenda { Id = a.Id, FechaBoda = a.FechaBoda, HoraBoda = a.HoraBoda, EstadoAgendaId = a.EstadoAgendaId }).ToListAsync();

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
