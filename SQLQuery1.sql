/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[name]
      ,[price]
      ,[company]
      ,[exp_date]
      ,[med_per_packet]
      ,[availlable]
      ,[storage_row]
      ,[storage_col]
  FROM [MediStock].[dbo].[Stock]


  SELECT * FROM Stock WHERE name = 'Peracitamol'