create database recept

use recept

create table kategoriak
(
	id int identity(1,1) primary key,
	nev varchar(50)
)

create table receptek
(
	id int identity(100,1) primary key,
	nev varchar(100),
	kat_id int,
	kep_eleresi_ut varchar(250),
	leiras varchar(300)
	foreign key(kat_id) references kategoriak(id)
)

insert into kategoriak values('f��tel')
insert into kategoriak values('leves')
insert into kategoriak values('�dess�g')
insert into kategoriak values('sal�ta')

select * from kategoriak

--tesztadat

insert into receptek values ('Soml�i galuska', 4, 'https://www.mindmegette.hu/images/352/Social/lead_Social_somloi-galuska-recept.jpg','Ritk�n j�runk cukr�szd�ba, ha �tba is vessz�k a kedvenc hely�nket, c�lir�nyosan tessz�k: soml�i galusk��rt megy�nk. Most el�sz�r megpr�b�lkoztam az elk�sz�t�s�vel itthon. Kiss� �des lett a v�geredm�ny, legk�zelebb a cukorszirupot kihagyom.')

alter table receptek
alter column leiras varchar(500)

insert into receptek values ('Paprik�s krumpli', 1, 'https://www.mindmegette.hu/images/230/O/img_4216.jpg', 'A paprik�s krumpli hazai kedvenc, amit ny�ron k�telez� bogr�csban elk�sz�teni. A szer�ny finoms�g rengeteg v�ltozatban k�sz�lhet, Szabolcsban hossz� l�vel, nokedlivel szokt�k f�zni, de t�szta n�lk�l, keny�rrel tunkolva is fejedelmi fog�s. A paprik�s krumpliba mindig ker�l h�sf�le, a legt�bb h�ztart�sban kolb�sszal k�sz�l, esetleg virsli vagy debreceni megy bele, de csak az egyikkel is el lehet k�sz�teni.')
