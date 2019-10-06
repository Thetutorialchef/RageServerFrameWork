﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rsf.Database;

namespace Server.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Server.resources.rsf.Models.CharacterBlendModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("CharacterModelId");

                    b.Property<byte>("ShapeFirst");

                    b.Property<float>("ShapeMix");

                    b.Property<byte>("ShapeSecond");

                    b.Property<byte>("SkinFirst");

                    b.Property<float>("SkinMix");

                    b.Property<byte>("SkinSecond");

                    b.HasKey("Id");

                    b.HasIndex("CharacterModelId");

                    b.ToTable("CharacterBlend");
                });

            modelBuilder.Entity("Server.resources.rsf.Models.CharacterFeaturesModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Augen");

                    b.Property<float>("Backenbreite");

                    b.Property<float>("Backenhoehe");

                    b.Property<float>("Brauenbreite");

                    b.Property<float>("Brauenhoehe");

                    b.Property<uint>("CharacterModelId");

                    b.Property<float>("Halsbreite");

                    b.Property<float>("Kinnbreite");

                    b.Property<float>("Kinnform");

                    b.Property<float>("Kinnlaenge");

                    b.Property<float>("Kinnposition");

                    b.Property<float>("Lippen");

                    b.Property<float>("Nasenbreite");

                    b.Property<float>("Nasenhoehe");

                    b.Property<float>("Nasenlaenge");

                    b.Property<float>("Nasenruecken");

                    b.Property<float>("Nasenrueckenverschiebung");

                    b.Property<float>("Nasenspitze");

                    b.Property<float>("Wangenbreite");

                    b.Property<float>("Wangenknochenbreite");

                    b.Property<float>("Wangenknochenhoehe");

                    b.HasKey("Id");

                    b.HasIndex("CharacterModelId");

                    b.ToTable("CharacterFeatures");
                });

            modelBuilder.Entity("Server.resources.rsf.Models.Clothes", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Drawable");

                    b.Property<bool>("Geschlecht");

                    b.Property<int>("Texture");

                    b.Property<int>("TorsoDrawable");

                    b.Property<int>("TorsoTexture");

                    b.Property<int>("UnterhemdDrawable");

                    b.Property<int>("UnterhemdTexture");

                    b.HasKey("Id");

                    b.ToTable("Clothes");
                });

            modelBuilder.Entity("Server.resources.rsf.Models.FraktionenModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("MaxRaenge");

                    b.Property<string>("Name");

                    b.Property<string>("Short");

                    b.HasKey("Id");

                    b.ToTable("Fraktionen");
                });

            modelBuilder.Entity("Server.resources.rsf.Models.FraktionsfahrzeugModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("BlinkerL");

                    b.Property<bool>("BlinkerR");

                    b.Property<uint>("Dimension");

                    b.Property<bool>("Engine");

                    b.Property<uint>("FraktionenModelId");

                    b.Property<int>("Livery");

                    b.Property<bool>("Locked");

                    b.Property<string>("Name");

                    b.Property<string>("NumberPlate");

                    b.Property<float>("PosX");

                    b.Property<float>("PosY");

                    b.Property<float>("PosZ");

                    b.Property<int>("PrimaryColor");

                    b.Property<float>("RotX");

                    b.Property<float>("RotY");

                    b.Property<float>("RotZ");

                    b.Property<int>("SecondaryColor");

                    b.HasKey("Id");

                    b.HasIndex("FraktionenModelId");

                    b.ToTable("Fraktionsfahrzeug");
                });

            modelBuilder.Entity("Server.resources.rsf.Models.FraktionskasseModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Betrag");

                    b.Property<uint>("FraktionenModelId");

                    b.HasKey("Id");

                    b.HasIndex("FraktionenModelId");

                    b.ToTable("Fraktionskasse");
                });

            modelBuilder.Entity("Server.resources.rsf.Models.FraktionsraengeModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Betrag");

                    b.Property<uint>("FraktionenModelId");

                    b.Property<string>("Name");

                    b.Property<byte>("Rang");

                    b.HasKey("Id");

                    b.HasIndex("FraktionenModelId");

                    b.ToTable("Fraktionsraenge");
                });

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

            modelBuilder.Entity("rsf.Models.CharacterOverlayModel", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

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

                    b.Property<int>("Frisur");

                    b.Property<byte>("FrisurFarbe");

                    b.Property<byte>("FrisurHighlights");

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

                    b.ToTable("CharacterOverlay");
                });

            modelBuilder.Entity("Server.resources.rsf.Models.CharacterBlendModel", b =>
                {
                    b.HasOne("rsf.Models.CharacterModel", "CharacterModel")
                        .WithMany()
                        .HasForeignKey("CharacterModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.resources.rsf.Models.CharacterFeaturesModel", b =>
                {
                    b.HasOne("rsf.Models.CharacterModel", "CharacterModel")
                        .WithMany()
                        .HasForeignKey("CharacterModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.resources.rsf.Models.FraktionsfahrzeugModel", b =>
                {
                    b.HasOne("Server.resources.rsf.Models.FraktionenModel", "FraktionenModel")
                        .WithMany()
                        .HasForeignKey("FraktionenModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.resources.rsf.Models.FraktionskasseModel", b =>
                {
                    b.HasOne("Server.resources.rsf.Models.FraktionenModel", "FraktionenModel")
                        .WithMany()
                        .HasForeignKey("FraktionenModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.resources.rsf.Models.FraktionsraengeModel", b =>
                {
                    b.HasOne("Server.resources.rsf.Models.FraktionenModel", "FraktionenModel")
                        .WithMany()
                        .HasForeignKey("FraktionenModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("rsf.Models.CharacterModel", b =>
                {
                    b.HasOne("rsf.Models.AccountModel", "AccountModel")
                        .WithMany()
                        .HasForeignKey("AccountModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("rsf.Models.CharacterOverlayModel", b =>
                {
                    b.HasOne("rsf.Models.CharacterModel", "CharacterModel")
                        .WithMany()
                        .HasForeignKey("CharacterModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
