--добавляем возможность использовать CDC, sql agent должен быть enabled.
EXEC sys.sp_cdc_enable_db;
GO
--добавляем таблицу в cdc
EXEC sys.sp_cdc_enable_table @source_schema = 'dbo', @source_name = 'contracts', @role_name = NULL, @supports_net_changes = 0;
GO
