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

insert into kategoriak values('fõétel')
insert into kategoriak values('leves')
insert into kategoriak values('édesség')
insert into kategoriak values('saláta')

select * from kategoriak

--tesztadat

insert into receptek values ('Somlói galuska', 4, 'https://www.mindmegette.hu/images/352/Social/lead_Social_somloi-galuska-recept.jpg','Ritkán járunk cukrászdába, ha útba is vesszük a kedvenc helyünket, célirányosan tesszük: somlói galuskáért megyünk. Most elõször megpróbálkoztam az elkészítésével itthon. Kissé édes lett a végeredmény, legközelebb a cukorszirupot kihagyom.')

alter table receptek
alter column leiras varchar(500)

insert into receptek values ('Paprikás krumpli', 1, 'https://www.mindmegette.hu/images/230/O/img_4216.jpg', 'A paprikás krumpli hazai kedvenc, amit nyáron kötelezõ bográcsban elkészíteni. A szerény finomság rengeteg változatban készülhet, Szabolcsban hosszú lével, nokedlivel szokták fõzni, de tészta nélkül, kenyérrel tunkolva is fejedelmi fogás. A paprikás krumpliba mindig kerül húsféle, a legtöbb háztartásban kolbásszal készül, esetleg virsli vagy debreceni megy bele, de csak az egyikkel is el lehet készíteni.')
