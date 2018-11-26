using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Correo = table.Column<string>(maxLength: 50, nullable: true),
                    TtooId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 150, nullable: true),
                    Iniciales = table.Column<string>(maxLength: 3, nullable: true),
                    AgenciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgendaId = table.Column<int>(nullable: false),
                    Comentarios = table.Column<string>(maxLength: 150, nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    FechaReg = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    ModuloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentosServicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentosServicios", x => new { x.DepartamentoId, x.ServicioId });
                });

            migrationBuilder.CreateTable(
                name: "DiasBloquedo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    Parcial = table.Column<bool>(nullable: false),
                    HoraInicio = table.Column<string>(maxLength: 20, nullable: true),
                    HoraFinal = table.Column<string>(maxLength: 20, nullable: true),
                    Locacion = table.Column<string>(maxLength: 20, nullable: true),
                    HotelId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasBloquedo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosAgenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Acronimo = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosAgenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgendaId = table.Column<int>(nullable: false),
                    ValorAnterior = table.Column<string>(maxLength: 50, nullable: true),
                    ValorNuevo = table.Column<string>(maxLength: 50, nullable: true),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaReg = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hora = table.Column<string>(maxLength: 20, nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hoteles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 30, nullable: true),
                    Clave = table.Column<string>(maxLength: 2, nullable: true),
                    Img = table.Column<string>(maxLength: 250, nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hotel = table.Column<string>(nullable: true),
                    AgendaId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: true),
                    TotalIncluido = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalAdicional = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalMaster = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DivisaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: true),
                    Clave = table.Column<string>(maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DivisaId = table.Column<int>(nullable: false),
                    Nota = table.Column<string>(maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Clave = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposCeremonia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCeremonia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ttoos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    HotelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ttoos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: true),
                    PrecioSugerido = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Nota = table.Column<string>(maxLength: 150, nullable: true),
                    Img = table.Column<string>(maxLength: 250, nullable: true),
                    CategoriaId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    DivisaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_Divisas_DivisaId",
                        column: x => x.DivisaId,
                        principalTable: "Divisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackUps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lugar = table.Column<string>(maxLength: 150, nullable: true),
                    HotelId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackUps_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LugaresCena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lugar = table.Column<string>(maxLength: 150, nullable: true),
                    HotelId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugaresCena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LugaresCena_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LugaresCeremonia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lugar = table.Column<string>(maxLength: 150, nullable: true),
                    HotelId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugaresCeremonia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LugaresCeremonia_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 15, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Apaterno = table.Column<string>(maxLength: 20, nullable: true),
                    Amaterno = table.Column<string>(maxLength: 20, nullable: true),
                    Correo = table.Column<string>(maxLength: 50, nullable: true),
                    Img = table.Column<string>(maxLength: 250, nullable: true),
                    Iniciales = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterFileContenido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MasterFileId = table.Column<int>(nullable: false),
                    ServicioId = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Img = table.Column<string>(maxLength: 150, nullable: true),
                    TieneImagen = table.Column<bool>(nullable: false),
                    Incluido = table.Column<bool>(nullable: false),
                    OcRequerido = table.Column<bool>(nullable: false),
                    OcRealizado = table.Column<bool>(nullable: false),
                    Nota = table.Column<string>(maxLength: 150, nullable: true),
                    Nota2 = table.Column<string>(maxLength: 150, nullable: true),
                    Nota3 = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFileContenido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterFileContenido_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteServicio",
                columns: table => new
                {
                    PaqueteId = table.Column<int>(nullable: false),
                    ServicioId = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteServicio", x => new { x.PaqueteId, x.ServicioId });
                    table.ForeignKey(
                        name: "FK_PaqueteServicio_Paquetes_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteServicio_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstadoAgendaId = table.Column<int>(nullable: false),
                    EjecutivoId = table.Column<int>(nullable: false),
                    FechaConfirmada = table.Column<DateTime>(type: "Date", nullable: true),
                    CordinadorId = table.Column<int>(nullable: false),
                    FechaBoda = table.Column<DateTime>(type: "Date", nullable: true),
                    HoraBoda = table.Column<string>(maxLength: 20, nullable: true),
                    LugarCeremoniaId = table.Column<int>(nullable: false),
                    LugarCenaId = table.Column<int>(nullable: false),
                    BackUpId = table.Column<int>(nullable: false),
                    TipoCeremoniaId = table.Column<int>(nullable: false),
                    Pax3raEdad = table.Column<int>(nullable: true),
                    PaxAdultos = table.Column<int>(nullable: true),
                    PaxJunior = table.Column<int>(nullable: true),
                    PaxNinos = table.Column<int>(nullable: true),
                    PaxCunas = table.Column<int>(nullable: true),
                    PaqueteId = table.Column<int>(nullable: false),
                    NombrePareja = table.Column<string>(maxLength: 50, nullable: true),
                    CorreoPareja = table.Column<string>(maxLength: 50, nullable: true),
                    Nacionalidad = table.Column<string>(maxLength: 2, nullable: true),
                    NombreAgente = table.Column<string>(maxLength: 50, nullable: true),
                    AgenciaId = table.Column<int>(nullable: false),
                    TtooId = table.Column<int>(nullable: false),
                    CorreoAgencia = table.Column<string>(maxLength: 50, nullable: true),
                    Deposito = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValue: 0m),
                    DivisaDeposito = table.Column<int>(nullable: true),
                    NumHabitacion = table.Column<int>(nullable: false),
                    BookingReference = table.Column<string>(maxLength: 30, nullable: true),
                    NumReserva = table.Column<string>(maxLength: 25, nullable: true),
                    Promocion = table.Column<string>(maxLength: 20, nullable: true),
                    Comision = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DivisaComision = table.Column<int>(nullable: true),
                    FechaSelloAuditoria = table.Column<DateTime>(type: "Date", nullable: true),
                    FechaPago = table.Column<DateTime>(type: "Date", nullable: true),
                    FechaLlegada = table.Column<DateTime>(type: "Date", nullable: true),
                    HotelId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    FechaReg = table.Column<DateTime>(nullable: false),
                    UsuarioMod = table.Column<int>(nullable: true),
                    FechaMod = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_BackUps_BackUpId",
                        column: x => x.BackUpId,
                        principalTable: "BackUps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendas_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_LugaresCena_LugarCenaId",
                        column: x => x.LugarCenaId,
                        principalTable: "LugaresCena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_LugaresCeremonia_LugarCeremoniaId",
                        column: x => x.LugarCeremoniaId,
                        principalTable: "LugaresCeremonia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Paquetes_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendas_TiposCeremonia_TipoCeremoniaId",
                        column: x => x.TipoCeremoniaId,
                        principalTable: "TiposCeremonia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioHotel",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioHotel", x => new { x.UsuarioId, x.HotelId });
                    table.ForeignKey(
                        name: "FK_UsuarioHotel_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioHotel_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_BackUpId",
                table: "Agendas",
                column: "BackUpId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_HotelId",
                table: "Agendas",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_LugarCenaId",
                table: "Agendas",
                column: "LugarCenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_LugarCeremoniaId",
                table: "Agendas",
                column: "LugarCeremoniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_PaqueteId",
                table: "Agendas",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_TipoCeremoniaId",
                table: "Agendas",
                column: "TipoCeremoniaId");

            migrationBuilder.CreateIndex(
                name: "IX_BackUps_HotelId",
                table: "BackUps",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_LugaresCena_HotelId",
                table: "LugaresCena",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_LugaresCeremonia_HotelId",
                table: "LugaresCeremonia",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterFileContenido_ServicioId",
                table: "MasterFileContenido",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicio_ServicioId",
                table: "PaqueteServicio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_CategoriaId",
                table: "Servicios",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_DivisaId",
                table: "Servicios",
                column: "DivisaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioHotel_HotelId",
                table: "UsuarioHotel",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RoleId",
                table: "Usuarios",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Agentes");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "DepartamentosServicios");

            migrationBuilder.DropTable(
                name: "DiasBloquedo");

            migrationBuilder.DropTable(
                name: "EstadosAgenda");

            migrationBuilder.DropTable(
                name: "Historial");

            migrationBuilder.DropTable(
                name: "Horas");

            migrationBuilder.DropTable(
                name: "MasterFile");

            migrationBuilder.DropTable(
                name: "MasterFileContenido");

            migrationBuilder.DropTable(
                name: "PaqueteServicio");

            migrationBuilder.DropTable(
                name: "Ttoos");

            migrationBuilder.DropTable(
                name: "UsuarioHotel");

            migrationBuilder.DropTable(
                name: "BackUps");

            migrationBuilder.DropTable(
                name: "LugaresCena");

            migrationBuilder.DropTable(
                name: "LugaresCeremonia");

            migrationBuilder.DropTable(
                name: "TiposCeremonia");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Hoteles");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Divisas");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
