/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[name]
      ,[price]
      ,[company]
      ,[exp_date]
      ,[med_per_packet]
      ,[available]
      ,[storage_row]
      ,[storage_col]
  FROM [MediStock].[dbo].[Stock]

  delete from Stock



  ALTER TABLE Stock ADD available int