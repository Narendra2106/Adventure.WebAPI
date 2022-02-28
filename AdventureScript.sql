

CREATE TABLE dbo.AdventureType
(
AdventureTypeId       INT IDENTITY(1,1) NOT NULL,
[Name]				  VARCHAR(100) NOT NULL,
CreatedBy			  VARCHAR(100) NOT NULL,
CreatedOn			  DATETIME NOT NULL ,
LastUpdatedBy		  VARCHAR(100), 
UpdatedOn			  DATETIME
)

ALTER TABLE dbo.AdventureType ADD CONSTRAINT PK_AdventureType_AdventureTypeId PRIMARY KEY(AdventureTypeId)

ALTER TABLE dbo.AdventureType ADD CONSTRAINT UQ_AdventureType_Name UNIQUE([Name])

GO

INSERT INTO dbo.AdventureType VALUES('DOUGHNUT DECISION HELPER','SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())

GO

CREATE TABLE dbo.Adventure
(
AdventureId                    INT IDENTITY(1,1) NOT NULL,
AdventureTypeId                INT NOT NULL,
Question                       VARCHAR(500) NOT NULL,
IfYesNextQuestionId            INT,
IfNoNextQuestionId			   INT, 	
CreatedBy					   VARCHAR(100) NOT NULL,
CreatedOn					   DATETIME NOT NULL ,
LastUpdatedBy				   VARCHAR(100), 
UpdatedOn					   DATETIME
)

GO

ALTER TABLE dbo.Adventure ADD CONSTRAINT PK_Adventure_AdventureId PRIMARY KEY(AdventureId)

ALTER TABLE dbo.Adventure ADD CONSTRAINT FK_Adventure_AdventureTypeId FOREIGN KEY(AdventureTypeId) REFERENCES dbo.AdventureType(AdventureTypeId)
GO


INSERT INTO dbo.Adventure VALUES(1,'Do I want a doughnut?',2,3,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())
INSERT INTO dbo.Adventure VALUES(1,'Do I deserve it?',4,5,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())
INSERT INTO dbo.Adventure VALUES(1,'Maybe you want an apple?',NULL,NULL,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())
INSERT INTO dbo.Adventure VALUES(1,'Are you sure?',6,7,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())
INSERT INTO dbo.Adventure VALUES(1,'Is it a good doughnut?',8,9,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())
INSERT INTO dbo.Adventure VALUES(1,'Get it.',NULL,NULL,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())
INSERT INTO dbo.Adventure VALUES(1,'Do jumping jacks first.',NULL,NULL,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())
INSERT INTO dbo.Adventure VALUES(1,'What are you waiting for? Grab it now.',NULL,NULL,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())
INSERT INTO dbo.Adventure VALUES(1,'Wait til you find a sinful, unforgettable doughnut.',NULL,NULL,'SYSTEM',GETUTCDATE(),'SYSTEM',GETUTCDATE())

GO
EXEC GetAdventureTree 1 
GO
CREATE proc [dbo].GetAdventureTree
	                    @FirstQuestionId int
                    as
                    with recursiveQuestions (AdventureId,AdventureTypeId, Question, IfYesNextQuestionId, IfNoNextQuestionId,Createdby,Createdon,Lastupdatedby,Updatedon)
                    as
                    (
	                    select * from Adventure where AdventureId = @FirstQuestionId
	                    union all
	                    select q.* from Adventure q
	                    join recursiveQuestions r on r.IfYesNextQuestionId = q.AdventureId
	                    where r.IfYesNextQuestionId is not null
	                    union all
	                    select q.* from Adventure q
	                    join recursiveQuestions r on r.IfNoNextQuestionId = q.AdventureId
	                    where r.IfNoNextQuestionId is not null
                    )
                    select * from recursiveQuestions








