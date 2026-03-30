using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SportApp.Models;

namespace SportApp.Data;

public partial class SportContext : DbContext
{
    public SportContext()
    {
    }

    public SportContext(DbContextOptions<SportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Stadium> Stadia { get; set; }

    public virtual DbSet<Stage> Stages { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("competition_pkey");

            entity.ToTable("competition");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_pkey");

            entity.ToTable("event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AwayTeamId).HasColumnName("away_team_id");
            entity.Property(e => e.CompetitionId).HasColumnName("competition_id");
            entity.Property(e => e.Datevenue).HasColumnName("datevenue");
            entity.Property(e => e.HomeTeamId).HasColumnName("home_team_id");
            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.Season).HasColumnName("season");
            entity.Property(e => e.Sport)
                .HasMaxLength(50)
                .HasColumnName("sport");
            entity.Property(e => e.StadiumId).HasColumnName("stadium_id");
            entity.Property(e => e.StageId).HasColumnName("stage_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TimevenueUtc).HasColumnName("timevenue_utc");

            entity.HasOne(d => d.AwayTeam).WithMany(p => p.EventAwayTeams)
                .HasForeignKey(d => d.AwayTeamId)
                .HasConstraintName("_fk_away_team");

            entity.HasOne(d => d.Competition).WithMany(p => p.Events)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("_fk_competition");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.EventHomeTeams)
                .HasForeignKey(d => d.HomeTeamId)
                .HasConstraintName("_fk_home_team");

            entity.HasOne(d => d.Result).WithMany(p => p.Events)
                .HasForeignKey(d => d.ResultId)
                .HasConstraintName("_fk_result");

            entity.HasOne(d => d.Stadium).WithMany(p => p.Events)
                .HasForeignKey(d => d.StadiumId)
                .HasConstraintName("_fk_stadium");

            entity.HasOne(d => d.Stage).WithMany(p => p.Events)
                .HasForeignKey(d => d.StageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("_fk_stage");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("result_pkey");

            entity.ToTable("result");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AwayGoals).HasColumnName("away_goals");
            entity.Property(e => e.HomeGoals).HasColumnName("home_goals");
            entity.Property(e => e.Message)
                .HasMaxLength(1000)
                .HasColumnName("message");
            entity.Property(e => e.Winner)
                .HasMaxLength(50)
                .HasColumnName("winner");
        });

        modelBuilder.Entity<Stadium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stadium_pkey");

            entity.ToTable("stadium");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .HasColumnName("place");
        });

        modelBuilder.Entity<Stage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stage_pkey");

            entity.ToTable("stage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Ordering).HasColumnName("ordering");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("team_pkey");

            entity.ToTable("team");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(3)
                .HasColumnName("abbreviation");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.OfficialName)
                .HasMaxLength(50)
                .HasColumnName("official_name");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .HasColumnName("slug");
            entity.Property(e => e.StagePosition).HasColumnName("stage_position");
            entity.Property(e => e.TeamCountryCode)
                .HasMaxLength(3)
                .HasColumnName("team_country_code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
