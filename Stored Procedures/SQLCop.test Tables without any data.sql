SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [SQLCop].[test Tables without any data]
AS
    BEGIN
	-- Written by George Mastros
	-- February 25, 2012
	-- http://sqlcop.lessthandot.com
	-- http://wiki.lessthandot.com/index.php/List_all_empty_tables_in_your_SQL_Server_database
	
        SET NOCOUNT ON;
	
        DECLARE @Output VARCHAR(MAX);
        SET @Output = '';

        CREATE TABLE #EmptyTables
            (
              Table_Name VARCHAR(100)
            );  
        EXEC sp_MSforeachtable 'IF NOT EXISTS(SELECT 1 FROM ?) INSERT INTO #EmptyTables VALUES(''?'')'; 
        SELECT  @Output = @Output + Table_Name + CHAR(13) + CHAR(10)
        FROM    #EmptyTables
        WHERE   LEFT(Table_Name, 7) <> '[tSQLt]'
                AND Table_Name <> '[dbo].[Area]'
                AND Table_Name <> '[dbo].[Manager]'
                AND Table_Name <> '[dbo].[Project]'
                AND Table_Name <> '[dbo].[ProjectWishList]'
                AND Table_Name <> '[dbo].[Rotation]'
				AND Table_Name <> '[dbo].[Goal]'
        ORDER BY Table_Name; 
        DROP TABLE #EmptyTables;

        IF @Output > ''
            BEGIN
                SET @Output = CHAR(13) + CHAR(10) + 'For more information:  '
                    + 'http://wiki.lessthandot.com/index.php/List_all_empty_tables_in_your_SQL_Server_database'
                    + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + @Output;
                EXEC tSQLt.Fail @Output;
            END;	  
    END;


GO
