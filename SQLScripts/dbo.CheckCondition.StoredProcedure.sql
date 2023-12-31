USE [IOWA.ITS4]
GO
/****** Object:  StoredProcedure [dbo].[CheckCondition]    Script Date: 19-09-2023 15:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CheckCondition]
    @MAPID int , 
	@ADJACENTMAPID int
AS
BEGIN
DECLARE @Result BIT
    -- Your condition
    IF EXISTS (SELECT * FROM tbl_rel_county_adjacency WHERE MAPID = @MAPID AND ADJACENTMAPID = @ADJACENTMAPID)
    BEGIN
        -- Set the result to true (1)
        SET @Result = 1;
    END
    ELSE
    BEGIN
        -- Set the result to false (0)
        SET @Result = 0;
    END
	Return @Result
END;
GO
