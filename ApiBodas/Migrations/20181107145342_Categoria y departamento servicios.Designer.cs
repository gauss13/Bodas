﻿// <auto-generated />
using System;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiBodas.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181107145342_Categoria y departamento servicios")]
    partial class Categoriaydepartamentoservicios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("AgenciaId");

                    b.Property<int>("BackUpId");

                    b.Property<string>("BookingReference")
                        .HasMaxLength(30);

                    b.Property<decimal>("Comision")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CordinadorId");

                    b.Property<string>("CorreoAgencia")
                        .HasMaxLength(50);

                    b.Property<string>("CorreoPareja")
                        .HasMaxLength(50);

                    b.Property<decimal>("Deposito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 2)")
                        .HasDefaultValue(0m);

                    b.Property<int?>("DivisaComision");

                    b.Property<int?>("DivisaDeposito");

                    b.Property<int>("EjecutivoId");

                    b.Property<int>("EstadoAgendaId");

                    b.Property<DateTime?>("FechaBoda")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("FechaConfirmada")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("FechaLlegada")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("FechaMod");

                    b.Property<DateTime?>("FechaPago")
                        .HasColumnType("Date");

                    b.Property<DateTime>("FechaReg");

                    b.Property<DateTime?>("FechaSelloAuditoria")
                        .HasColumnType("Date");

                    b.Property<string>("HoraBoda")
                        .HasMaxLength(20);

                    b.Property<int>("HotelId");

                    b.Property<int>("LugarCenaId");

                    b.Property<int>("LugarCeremoniaId");

                    b.Property<string>("Nacionalidad")
                        .HasMaxLength(2);

                    b.Property<string>("NombreAgente")
                        .HasMaxLength(50);

                    b.Property<string>("NombrePareja")
                        .HasMaxLength(50);

                    b.Property<int>("NumHabitacion");

                    b.Property<string>("NumReserva")
                        .HasMaxLength(25);

                    b.Property<int>("PaqueteId");

                    b.Property<int?>("Pax3raEdad");

                    b.Property<int?>("PaxAdultos");

                    b.Property<int?>("PaxCunas");

                    b.Property<int?>("PaxJunior");

                    b.Property<int?>("PaxNinos");

                    b.Property<string>("Promocion")
                        .HasMaxLength(20);

                    b.Property<int>("TipoCeremoniaId");

                    b.Property<int>("TtooId");

                    b.Property<int>("UsuarioId");

                    b.Property<int?>("UsuarioMod");

                    b.HasKey("Id");

                    b.HasIndex("BackUpId");

                    b.HasIndex("HotelId");

                    b.HasIndex("LugarCenaId");

                    b.HasIndex("LugarCeremoniaId");

                    b.HasIndex("PaqueteId");

                    b.HasIndex("TipoCeremoniaId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Correo")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.Property<int>("TtooId");

                    b.HasKey("Id");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.Agente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgenciaId");

                    b.Property<string>("Iniciales")
                        .HasMaxLength(3);

                    b.Property<string>("Nombre")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Agentes");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.BackUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("HotelId");

                    b.Property<string>("Lugar")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("BackUps");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.Divisa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Divisas");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.Horas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hora")
                        .HasMaxLength(20);

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Horas");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Clave")
                        .HasMaxLength(2);

                    b.Property<string>("Img")
                        .HasMaxLength(250);

                    b.Property<string>("Nombre")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Hoteles");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.LugarCena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("HotelId");

                    b.Property<string>("Lugar")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("LugaresCena");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.LugarCeremonia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("HotelId");

                    b.Property<string>("Lugar")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("LugaresCeremonia");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.TipoCeremonia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TiposCeremonia");
                });

            modelBuilder.Entity("Entities.Models.Catalogos.Ttoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("HotelId");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Ttoos");
                });

            modelBuilder.Entity("Entities.Models.EstadoAgenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acronimo")
                        .HasMaxLength(3);

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("EstadosAgenda");
                });

            modelBuilder.Entity("Entities.Models.Extras.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("AgendaId");

                    b.Property<string>("Comentarios")
                        .HasMaxLength(150);

                    b.Property<DateTime>("FechaReg");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Entities.Models.Extras.DiasBloqueados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<string>("HoraFinal")
                        .HasMaxLength(20);

                    b.Property<string>("HoraInicio")
                        .HasMaxLength(20);

                    b.Property<int>("HotelId");

                    b.Property<string>("Locacion")
                        .HasMaxLength(20);

                    b.Property<bool>("Parcial");

                    b.HasKey("Id");

                    b.ToTable("DiasBloquedo");
                });

            modelBuilder.Entity("Entities.Models.Extras.Historial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgendaId");

                    b.Property<DateTime>("FechaReg");

                    b.Property<int>("IdUsuario");

                    b.Property<string>("ValorAnterior")
                        .HasMaxLength(50);

                    b.Property<string>("ValorNuevo")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Historial");
                });

            modelBuilder.Entity("Entities.Models.Masterfiles.MasterFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("AgendaId");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Hotel");

                    b.HasKey("Id");

                    b.ToTable("MasterFile");
                });

            modelBuilder.Entity("Entities.Models.Masterfiles.MasterFileContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adicional");

                    b.Property<int>("Cantidad");

                    b.Property<int>("DivisaId");

                    b.Property<string>("Img")
                        .HasMaxLength(150);

                    b.Property<int>("MasterFileId");

                    b.Property<bool>("OcRealizado");

                    b.Property<bool>("OcRequerido");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ServicioId");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("MasterFileContenido");
                });

            modelBuilder.Entity("Entities.Models.Paquetes.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<int>("HotelId");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Entities.Models.Paquetes.Paquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Clave")
                        .HasMaxLength(50);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<int>("HotelId");

                    b.HasKey("Id");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("Entities.Models.Paquetes.PaqueteServicio", b =>
                {
                    b.Property<int>("PaqueteId");

                    b.Property<int>("ServicioId");

                    b.HasKey("PaqueteId", "ServicioId");

                    b.HasIndex("ServicioId");

                    b.ToTable("PaqueteServicio");
                });

            modelBuilder.Entity("Entities.Models.Paquetes.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int?>("CategoriaId");

                    b.Property<int>("CategoriaServicioId");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<int>("DivisaId");

                    b.Property<int>("HotelId");

                    b.Property<string>("Img")
                        .HasMaxLength(250);

                    b.Property<string>("Nota")
                        .HasMaxLength(150);

                    b.Property<decimal>("PrecioSugerido")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("DivisaId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Entities.Models.Usuarios.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .HasMaxLength(2);

                    b.Property<string>("Nombre")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Entities.Models.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amaterno")
                        .HasMaxLength(20);

                    b.Property<string>("Apaterno")
                        .HasMaxLength(20);

                    b.Property<string>("Correo")
                        .HasMaxLength(50);

                    b.Property<string>("Img")
                        .HasMaxLength(250);

                    b.Property<string>("Iniciales")
                        .HasMaxLength(3);

                    b.Property<string>("Nombre")
                        .HasMaxLength(20);

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entities.Models.Usuarios.UsuarioHotel", b =>
                {
                    b.Property<int>("UsuarioId");

                    b.Property<int>("HotelId");

                    b.Property<bool>("Activo");

                    b.HasKey("UsuarioId", "HotelId");

                    b.HasIndex("HotelId");

                    b.ToTable("UsuarioHotel");
                });

            modelBuilder.Entity("Entities.Models.Agenda", b =>
                {
                    b.HasOne("Entities.Models.Catalogos.BackUp", "BackUp")
                        .WithMany("Agendas")
                        .HasForeignKey("BackUpId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Models.Catalogos.Hotel", "Hotel")
                        .WithMany("Agendas")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Models.Catalogos.LugarCena", "LugarCena")
                        .WithMany("Agendas")
                        .HasForeignKey("LugarCenaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Models.Catalogos.LugarCeremonia", "LugarCeremonia")
                        .WithMany("Agendas")
                        .HasForeignKey("LugarCeremoniaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Models.Paquetes.Paquete", "Paquete")
                        .WithMany()
                        .HasForeignKey("PaqueteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Models.Catalogos.TipoCeremonia", "TipoCeremonia")
                        .WithMany()
                        .HasForeignKey("TipoCeremoniaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Models.Catalogos.BackUp", b =>
                {
                    b.HasOne("Entities.Models.Catalogos.Hotel", "Hotel")
                        .WithMany("BackUps")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Models.Catalogos.LugarCena", b =>
                {
                    b.HasOne("Entities.Models.Catalogos.Hotel", "Hotel")
                        .WithMany("LugaresCena")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Models.Catalogos.LugarCeremonia", b =>
                {
                    b.HasOne("Entities.Models.Catalogos.Hotel", "Hotel")
                        .WithMany("LugaresCeremonia")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Models.Paquetes.PaqueteServicio", b =>
                {
                    b.HasOne("Entities.Models.Paquetes.Paquete", "Paquete")
                        .WithMany("PaqueteServicios")
                        .HasForeignKey("PaqueteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Models.Paquetes.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Models.Paquetes.Servicio", b =>
                {
                    b.HasOne("Entities.Models.Paquetes.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Entities.Models.Catalogos.Divisa", "Divisa")
                        .WithMany()
                        .HasForeignKey("DivisaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Models.Usuarios.Usuario", b =>
                {
                    b.HasOne("Entities.Models.Usuarios.Role", "Role")
                        .WithMany("Usuarios")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Models.Usuarios.UsuarioHotel", b =>
                {
                    b.HasOne("Entities.Models.Catalogos.Hotel", "Hotel")
                        .WithMany("UsuariosHotel")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Models.Usuarios.Usuario", "Usuario")
                        .WithMany("UsuariosHotel")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
