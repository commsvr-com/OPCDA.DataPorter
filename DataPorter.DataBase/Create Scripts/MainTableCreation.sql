IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'OPCDataTable')
	BEGIN
		DROP  Table OPCDataTable
	END
GO

CREATE TABLE OPCDataTable
(
   	[timestamp] [datetime] NOT NULL,
   	[name] [nchar](255) NOT NULL,
	[opcvalue] [float] NULL,
	[opcquality] [nchar](20) NULL
)
GO
