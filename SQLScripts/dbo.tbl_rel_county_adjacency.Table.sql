USE [IOWA.ITS4]
GO
/****** Object:  Table [dbo].[tbl_rel_county_adjacency]    Script Date: 19-09-2023 15:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_rel_county_adjacency](
	[MapID] [int] NOT NULL,
	[AdjacentMapID] [int] NOT NULL
) ON [PRIMARY]
GO
