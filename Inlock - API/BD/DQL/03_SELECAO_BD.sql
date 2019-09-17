use T_InLock

select * from Usuarios
select * from Estudios 
select * from Jogos ORDER BY DataLancamento DESC;

select J.NomeJogo, E.NomeEstudio
from Jogos j
join Estudios E
on J.EstudioId = E.EstudioId 

select J.NomeJogo, E.NomeEstudio
from Jogos j
right join Estudios E
on J.EstudioId = E.EstudioId 

select * from Usuarios
where Email = 'admin@admin.com' and Senha = 'admin'

select * from Jogos where JogoId = 1

select * from Estudios where EstudioId = 4


