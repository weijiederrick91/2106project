namespace Team11_2106Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminViewModels",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        VoterID = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        HasVoted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.CampaignDateViewModels",
                c => new
                    {
                        CampaignID = c.Int(nullable: false, identity: true),
                        EndDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CampaignID);
            
            CreateTable(
                "dbo.CandidateProfileViewModels",
                c => new
                    {
                        CandidateID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentYear = c.Int(nullable: false),
                        Introduction = c.String(),
                        CCA = c.String(),
                    })
                .PrimaryKey(t => t.CandidateID);
            
            CreateTable(
                "dbo.CandidateViewModels",
                c => new
                    {
                        CandidateID = c.Int(nullable: false, identity: true),
                        TotalVotes = c.Int(nullable: false),
                        VoterID = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        HasVoted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateID);
            
            CreateTable(
                "dbo.RalliesViewModels",
                c => new
                    {
                        RalliesID = c.Int(nullable: false, identity: true),
                        CandidateID = c.String(),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RalliesID);
            
            CreateTable(
                "dbo.VoterViewModels",
                c => new
                    {
                        VoterID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        HasVoted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VoterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VoterViewModels");
            DropTable("dbo.RalliesViewModels");
            DropTable("dbo.CandidateViewModels");
            DropTable("dbo.CandidateProfileViewModels");
            DropTable("dbo.CampaignDateViewModels");
            DropTable("dbo.AdminViewModels");
        }
    }
}
