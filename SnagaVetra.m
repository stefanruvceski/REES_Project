%% Koeficijent korisnog dejstva
% teorijski max = 0.59, prakticno izmedju 0.25 i 0.45
% 100 slucajnih vrednosti u opsegu 0.25 - 0.45
koeficijent = 0.25 + (0.45 - 0.25) .* rand(100, 1);     

%% Poluprecnik turbine
% 100 slucajnih vrednosti u opsegu 30 - 90 metara
poluprecnik = 30 + (90 - 30) .* rand(100, 1);                        

%% Brzina vetra
% 100 slucajnih vrednosti u opsegu 0.5 - 18 m/s
brzinaVetra = 0.5 + (18 - 0.5) .* rand(100, 1);

%% Gustina vazduha
gustinaVazduha = 1.29;      % uzeto kao konstantna vrednost

%% Povrsina turbine
% dobija se iz poluprecnika
povrsina = poluprecnik .^ 2 .* pi;

%% Snaga
P = 0.5 * gustinaVazduha * koeficijent .* povrsina .* (brzinaVetra .^ 3)
format long g