

-- Description : Retieve all datas from  table  => UserLevel  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_UserLevel_BY_ID]
  (@IdUserLevel int)
AS
BEGIN
SELECT [UserLevel].[IdUserLevel] , [UserLevel].[Name] , [UserLevel].[RateMin] , [UserLevel].[RateMax] , [UserLevel].[Description] 
	FROM [dbo].[UserLevel] (nolock) as [UserLevel]
 WHERE [IdUserLevel]=@IdUserLevel;
    END