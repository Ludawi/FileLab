using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FileLab.Migrations.FileDb
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'Files') THEN
                        CREATE TABLE ""Files"" (
                            ""Id"" SERIAL PRIMARY KEY,
                            ""FileName"" TEXT NOT NULL,
                            ""FileContent"" BYTEA NOT NULL,
                            ""UploadDate"" TIMESTAMPTZ NOT NULL,
                            ""LastChanged"" TIMESTAMPTZ NOT NULL
                        );
                    END IF;
                END
                $$;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
