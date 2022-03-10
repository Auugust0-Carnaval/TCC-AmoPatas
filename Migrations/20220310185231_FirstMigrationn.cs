using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmoPatass.Migrations
{
    public partial class FirstMigrationn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCatetegoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCatetegoria);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    idPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmPessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPerfil = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RedeSocial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.idPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Portes",
                columns: table => new
                {
                    IdPorte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portes", x => x.IdPorte);
                });

            migrationBuilder.CreateTable(
                name: "Rgas",
                columns: table => new
                {
                    IdRga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsRga = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rgas", x => x.IdRga);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    IdSexo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.IdSexo);
                });

            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    IdSituacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsSituacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.IdSituacao);
                });

            migrationBuilder.CreateTable(
                name: "Racas",
                columns: table => new
                {
                    IdRaca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaIdCatetegoria = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    dsRaca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racas", x => x.IdRaca);
                    table.ForeignKey(
                        name: "FK_Racas_Categorias_CategoriaIdCatetegoria",
                        column: x => x.CategoriaIdCatetegoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCatetegoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFoto",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoasidPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFoto", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_PessoaFoto_Pessoas_PessoasidPessoa",
                        column: x => x.PessoasidPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preferencias",
                columns: table => new
                {
                    PessoasidPessoa = table.Column<int>(type: "int", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    sqPreferencia = table.Column<int>(type: "int", nullable: false),
                    PorteIdPorte = table.Column<int>(type: "int", nullable: false),
                    IdPorte = table.Column<int>(type: "int", nullable: false),
                    SexoIdSexo = table.Column<int>(type: "int", nullable: false),
                    IdSexo = table.Column<int>(type: "int", nullable: false),
                    mtPreferencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaIdCatetegoria = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Preferencias_Categorias_CategoriaIdCatetegoria",
                        column: x => x.CategoriaIdCatetegoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCatetegoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferencias_Pessoas_PessoasidPessoa",
                        column: x => x.PessoasidPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferencias_Portes_PorteIdPorte",
                        column: x => x.PorteIdPorte,
                        principalTable: "Portes",
                        principalColumn: "IdPorte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferencias_Sexos_SexoIdSexo",
                        column: x => x.SexoIdSexo,
                        principalTable: "Sexos",
                        principalColumn: "IdSexo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtAdocao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cdAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UfAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    RgaIdRga = table.Column<int>(type: "int", nullable: false),
                    IdRga = table.Column<int>(type: "int", nullable: true),
                    PorteIdPorte = table.Column<int>(type: "int", nullable: false),
                    IdPorte = table.Column<int>(type: "int", nullable: false),
                    PessoasidPessoa = table.Column<int>(type: "int", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    RacasIdRaca = table.Column<int>(type: "int", nullable: false),
                    IdRaca = table.Column<int>(type: "int", nullable: false),
                    CategoriaIdCatetegoria = table.Column<int>(type: "int", nullable: false),
                    IdCatetegoria = table.Column<int>(type: "int", nullable: false),
                    SituacoesIdSituacao = table.Column<int>(type: "int", nullable: false),
                    IdSituacao = table.Column<int>(type: "int", nullable: false),
                    SexoIdSexo = table.Column<int>(type: "int", nullable: false),
                    IdSexo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.IdAnimal);
                    table.ForeignKey(
                        name: "FK_Pets_Categorias_CategoriaIdCatetegoria",
                        column: x => x.CategoriaIdCatetegoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCatetegoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Pessoas_PessoasidPessoa",
                        column: x => x.PessoasidPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Portes_PorteIdPorte",
                        column: x => x.PorteIdPorte,
                        principalTable: "Portes",
                        principalColumn: "IdPorte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Racas_RacasIdRaca",
                        column: x => x.RacasIdRaca,
                        principalTable: "Racas",
                        principalColumn: "IdRaca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Rgas_RgaIdRga",
                        column: x => x.RgaIdRga,
                        principalTable: "Rgas",
                        principalColumn: "IdRga",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Sexos_SexoIdSexo",
                        column: x => x.SexoIdSexo,
                        principalTable: "Sexos",
                        principalColumn: "IdSexo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Situacoes_SituacoesIdSituacao",
                        column: x => x.SituacoesIdSituacao,
                        principalTable: "Situacoes",
                        principalColumn: "IdSituacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimaisFotos",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetsIdAnimal = table.Column<int>(type: "int", nullable: false),
                    ftAnimal = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimaisFotos", x => x.IdAnimal);
                    table.ForeignKey(
                        name: "FK_AnimaisFotos_Pets_PetsIdAnimal",
                        column: x => x.PetsIdAnimal,
                        principalTable: "Pets",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interessados",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    idAnimal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interessados", x => new { x.IdPessoa, x.idAnimal });
                    table.ForeignKey(
                        name: "FK_Interessados_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interessados_Pets_idAnimal",
                        column: x => x.idAnimal,
                        principalTable: "Pets",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimaisFotos_PetsIdAnimal",
                table: "AnimaisFotos",
                column: "PetsIdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Interessados_idAnimal",
                table: "Interessados",
                column: "idAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFoto_PessoasidPessoa",
                table: "PessoaFoto",
                column: "PessoasidPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CategoriaIdCatetegoria",
                table: "Pets",
                column: "CategoriaIdCatetegoria");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PessoasidPessoa",
                table: "Pets",
                column: "PessoasidPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PorteIdPorte",
                table: "Pets",
                column: "PorteIdPorte");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_RacasIdRaca",
                table: "Pets",
                column: "RacasIdRaca");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_RgaIdRga",
                table: "Pets",
                column: "RgaIdRga");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SexoIdSexo",
                table: "Pets",
                column: "SexoIdSexo");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SituacoesIdSituacao",
                table: "Pets",
                column: "SituacoesIdSituacao");

            migrationBuilder.CreateIndex(
                name: "IX_Preferencias_CategoriaIdCatetegoria",
                table: "Preferencias",
                column: "CategoriaIdCatetegoria");

            migrationBuilder.CreateIndex(
                name: "IX_Preferencias_PessoasidPessoa",
                table: "Preferencias",
                column: "PessoasidPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Preferencias_PorteIdPorte",
                table: "Preferencias",
                column: "PorteIdPorte");

            migrationBuilder.CreateIndex(
                name: "IX_Preferencias_SexoIdSexo",
                table: "Preferencias",
                column: "SexoIdSexo");

            migrationBuilder.CreateIndex(
                name: "IX_Racas_CategoriaIdCatetegoria",
                table: "Racas",
                column: "CategoriaIdCatetegoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimaisFotos");

            migrationBuilder.DropTable(
                name: "Interessados");

            migrationBuilder.DropTable(
                name: "PessoaFoto");

            migrationBuilder.DropTable(
                name: "Preferencias");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Portes");

            migrationBuilder.DropTable(
                name: "Racas");

            migrationBuilder.DropTable(
                name: "Rgas");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "Situacoes");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
