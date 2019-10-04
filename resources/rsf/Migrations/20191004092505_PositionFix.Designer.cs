﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rsf.Database;

namespace rsf.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20191004092505_PositionFix")]
    partial class PositionFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("rsf.Models.AccountModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<DateTime?>("EndBannedTime");

                    b.Property<string>("Ip");

                    b.Property<int>("MaxCharacters");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("SocialClubName");

                    b.Property<string>("TeamSpeakUniqueId");

                    b.Property<int>("WhiteListed");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("rsf.Models.CharacterDatenModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("AddBodyBlemish");

                    b.Property<byte>("Ageing");

                    b.Property<float>("AgeingOpacity");

                    b.Property<byte>("AgeingPrimaryColor");

                    b.Property<byte>("AgeingSecondaryColor");

                    b.Property<byte>("Blemish");

                    b.Property<float>("BlemishOpacity");

                    b.Property<byte>("BlemishPrimaryColor");

                    b.Property<byte>("BlemishSecondaryColor");

                    b.Property<byte>("Blush");

                    b.Property<float>("BlushOpacity");

                    b.Property<byte>("BlushPrimaryColor");

                    b.Property<byte>("BlushSecondaryColor");

                    b.Property<byte>("BodyBlemish");

                    b.Property<float>("BodyBlemishOpacity");

                    b.Property<byte>("BodyBlemishPrimaryColor");

                    b.Property<byte>("BodyBlemishSecondaryColor");

                    b.Property<uint>("CharacterModelId");

                    b.Property<byte>("ChestHair");

                    b.Property<float>("ChestHairOpacity");

                    b.Property<byte>("ChestHairPrimaryColor");

                    b.Property<byte>("ChestHairSecondaryColor");

                    b.Property<byte>("Complexion");

                    b.Property<float>("ComplexionOpacity");

                    b.Property<byte>("ComplexionPrimaryColor");

                    b.Property<byte>("ComplexionSecondaryColor");

                    b.Property<byte>("Eyebrows");

                    b.Property<float>("EyebrowsOpacity");

                    b.Property<byte>("EyebrowsPrimaryColor");

                    b.Property<byte>("EyebrowsSecondaryColor");

                    b.Property<byte>("FacialHair");

                    b.Property<float>("FacialHairOpacity");

                    b.Property<byte>("FacialHairPrimaryColor");

                    b.Property<byte>("FacialHairSecondaryColor");

                    b.Property<byte>("Lipstick");

                    b.Property<float>("LipstickOpacity");

                    b.Property<byte>("LipstickPrimaryColor");

                    b.Property<byte>("LipstickSecondaryColor");

                    b.Property<byte>("Makeup");

                    b.Property<float>("MakeupOpacity");

                    b.Property<byte>("MakeupPrimaryColor");

                    b.Property<byte>("MakeupSecondaryColor");

                    b.Property<byte>("Moles");

                    b.Property<float>("MolesOpacity");

                    b.Property<byte>("MolesPrimaryColor");

                    b.Property<byte>("MolesSecondaryColor");

                    b.Property<ushort>("Schriftart");

                    b.Property<byte>("SunDamage");

                    b.Property<float>("SunDamageOpacity");

                    b.Property<byte>("SunDamagePrimaryColor");

                    b.Property<byte>("SunDamageSecondaryColor");

                    b.HasKey("Id");

                    b.HasIndex("CharacterModelId");

                    b.ToTable("CharacterDaten");
                });

            modelBuilder.Entity("rsf.Models.CharacterModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountBalance");

                    b.Property<uint>("AccountModelId");

                    b.Property<double>("Bank");

                    b.Property<int>("Dead");

                    b.Property<byte>("Familienstand");

                    b.Property<DateTime>("Geburtsdatum");

                    b.Property<string>("Geburtsort")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Geschlecht");

                    b.Property<int>("Jail");

                    b.Property<int>("Jailtime");

                    b.Property<int>("JobId");

                    b.Property<int>("JobRank");

                    b.Property<double>("Money");

                    b.Property<string>("Nachname")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OnDuty");

                    b.Property<float>("PosX");

                    b.Property<float>("PosY");

                    b.Property<float>("PosZ");

                    b.Property<int>("RoleId");

                    b.Property<float>("RotX");

                    b.Property<float>("RotY");

                    b.Property<float>("RotZ");

                    b.Property<byte>("Schriftart");

                    b.Property<int>("Sex");

                    b.Property<string>("Staatsangehoerigkeit")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Vorname")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("WJobId");

                    b.Property<int>("Wantedlevel");

                    b.HasKey("Id");

                    b.HasIndex("AccountModelId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("rsf.Models.CharacterDatenModel", b =>
                {
                    b.HasOne("rsf.Models.CharacterModel", "CharacterModel")
                        .WithMany()
                        .HasForeignKey("CharacterModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("rsf.Models.CharacterModel", b =>
                {
                    b.HasOne("rsf.Models.AccountModel", "AccountModel")
                        .WithMany()
                        .HasForeignKey("AccountModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
