--drop view Ataskaita

create view Ataskaita as 
select 
	 s.id as SkaitytojoId,
	 uzs.id as UzsakymoId,
	 s.Pavarde,
	 s.Vardas, 
	 CONVERT(VARCHAR(10), uzs.Uzsakymo_Data, 111) as paimta,
	CONVERT(VARCHAR(10), uzs.Grazinimo_Data, 111) as grazinti,
  (select STRING_AGG(Knygos.Pav ,'; ' ) AS kkk
		from Uzsakymai u 
		left join UzsakymaiKnygos uk on uk.UzsakymasId = u.Id
		left join Knygos ON uk.KnygaId = Knygos.Id
		where u.SkaitytojasId = s.Id
  )knygu_suma,
  (select COUNT(*)
		from Uzsakymai u 
		inner join UzsakymaiKnygos uk on uk.UzsakymasId = u.Id
		inner join Knygos ON uk.KnygaId = Knygos.Id
		where u.SkaitytojasId = s.Id
		) knygu_count,
------
  (select STRING_AGG(Zurnalai.Pav ,';' ) AS zzz
		from Uzsakymai u 
		LEFT JOIN UzsakymaiZurnalai ON u.Id = UzsakymaiZurnalai.UzsakymasId
		LEFT JOIN Zurnalai ON UzsakymaiZurnalai.ZurnalasId = Zurnalai.Id
		where u.SkaitytojasId = s.Id
  ) as zurnalu_suma,
  (select COUNT(*)
		from Uzsakymai u 
		inner JOIN UzsakymaiZurnalai ON u.Id = UzsakymaiZurnalai.UzsakymasId
		inner JOIN Zurnalai ON UzsakymaiZurnalai.ZurnalasId = Zurnalai.Id
		where u.SkaitytojasId = s.Id
  ) as zurnalu_count,
  

  --------

  (select STRING_AGG(AudioKnygos.Pav ,'; ' ) AS aaa
		from Uzsakymai u 
		LEFT JOIN UzsakymaiAudioKnygos ON u.Id = UzsakymaiAudioKnygos.UzsakymasId
		LEFT JOIN AudioKnygos ON UzsakymaiAudioKnygos.AudioKnygaId = AudioKnygos.Id
		where u.SkaitytojasId = s.Id
  ) as audio_suma,
  (select COUNT(*)
		from Uzsakymai u 
		inner JOIN UzsakymaiAudioKnygos ON u.Id = UzsakymaiAudioKnygos.UzsakymasId
		inner JOIN AudioKnygos ON UzsakymaiAudioKnygos.AudioKnygaId = AudioKnygos.Id
		where u.SkaitytojasId = s.Id
  ) as audio_count ,

  --- sumavimas
  (select COUNT(*)
		from Uzsakymai u 
		inner join UzsakymaiKnygos uk on uk.UzsakymasId = u.Id
		inner join Knygos ON uk.KnygaId = Knygos.Id
		where u.SkaitytojasId = s.Id
		) +
	(select COUNT(*)
		from Uzsakymai u 
		inner JOIN UzsakymaiAudioKnygos ON u.Id = UzsakymaiAudioKnygos.UzsakymasId
		inner JOIN AudioKnygos ON UzsakymaiAudioKnygos.AudioKnygaId = AudioKnygos.Id
		where u.SkaitytojasId = s.Id
  ) +

  (select COUNT(*)
		from Uzsakymai u 
		inner JOIN UzsakymaiZurnalai ON u.Id = UzsakymaiZurnalai.UzsakymasId
		inner JOIN Zurnalai ON UzsakymaiZurnalai.ZurnalasId = Zurnalai.Id
		where u.SkaitytojasId = s.Id
  ) as leidiniai
  from Skaitytojai s
  INNer join Uzsakymai uzs on s.ID = uzs.SkaitytojasId
