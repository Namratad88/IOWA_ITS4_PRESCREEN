USE [IOWA.ITS4]
GO
/****** Object:  StoredProcedure [dbo].[CountyNames]    Script Date: 19-09-2023 15:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[CountyNames]
    @MAPID int , 
    @ADJACENTMAPID int
AS
BEGIN
				SELECT countytbl.CountyName 
				FROM(VALUES(1, @MAPID), (2, @ADJACENTMAPID)) temptbl([rn], [id])
				JOIN [dbo].[tbl_mas_county] countytbl
				ON countytbl.[MapID] = temptbl.[id]
				ORDER BY temptbl.[rn]
  
END;
GO
