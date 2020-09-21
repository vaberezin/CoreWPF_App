using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWpfApp.Migrations
{
    public partial class plusRegulations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pril11_region_id_hcp_cv_cs",
                columns: table => new
                {
                    regionName = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    reionId = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Havg = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    c_v = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    c_s = table.Column<decimal>(type: "decimal(6,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.regionName);
                });

            migrationBuilder.CreateTable(
                name: "pril2_n_pless_pabove_mr_gamma",
                columns: table => new
                {
                    region = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    n_pless1 = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    n_pabove1 = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    mr = table.Column<int>(nullable: false),
                    gamma = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.region);
                });

            migrationBuilder.CreateTable(
                name: "Regulations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegName = table.Column<string>(nullable: true),
                    RegCode = table.Column<string>(nullable: true),
                    RegLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "table_9_k",
                columns: table => new
                {
                    F = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    K = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.F);
                });

            migrationBuilder.CreateTable(
                name: "table10_zi_psyi",
                columns: table => new
                {
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    z_i = table.Column<decimal>(type: "decimal(7,3)", nullable: false),
                    psy_i = table.Column<decimal>(type: "decimal(7,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "table11_zi_vodonepronitsaemie",
                columns: table => new
                {
                    a = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nLess065 = table.Column<decimal>(type: "decimal(7,3)", nullable: false),
                    nAbove065 = table.Column<decimal>(type: "decimal(7,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.a);
                });

            migrationBuilder.CreateTable(
                name: "table12_sloy_talikh_vod",
                columns: table => new
                {
                    climateId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    P995 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P495 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P328 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P095 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P045 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P015 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P010 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P005 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P0022 = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    P0033 = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.climateId);
                });

            migrationBuilder.CreateTable(
                name: "table13_r_tau",
                columns: table => new
                {
                    c = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    tau = table.Column<decimal>(type: "decimal(6,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.c);
                });

            migrationBuilder.CreateTable(
                name: "table14_h_plim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    h_rain = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Plim = table.Column<decimal>(type: "decimal(7,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table14_h_plim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "table15_k1_plim_c_n",
                columns: table => new
                {
                    Plim = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C085nLess07 = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C085nAbove07 = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C100nLess07 = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C100nAbove07 = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C120nLess07 = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C120nAbove07 = table.Column<decimal>(type: "decimal(6,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Plim);
                });

            migrationBuilder.CreateTable(
                name: "table16_k2_plim_c",
                columns: table => new
                {
                    P = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C085 = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C100 = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    C120 = table.Column<decimal>(type: "decimal(6,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.P);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pril11_region_id_hcp_cv_cs");

            migrationBuilder.DropTable(
                name: "pril2_n_pless_pabove_mr_gamma");

            migrationBuilder.DropTable(
                name: "Regulations");

            migrationBuilder.DropTable(
                name: "table_9_k");

            migrationBuilder.DropTable(
                name: "table10_zi_psyi");

            migrationBuilder.DropTable(
                name: "table11_zi_vodonepronitsaemie");

            migrationBuilder.DropTable(
                name: "table12_sloy_talikh_vod");

            migrationBuilder.DropTable(
                name: "table13_r_tau");

            migrationBuilder.DropTable(
                name: "table14_h_plim");

            migrationBuilder.DropTable(
                name: "table15_k1_plim_c_n");

            migrationBuilder.DropTable(
                name: "table16_k2_plim_c");
        }
    }
}
