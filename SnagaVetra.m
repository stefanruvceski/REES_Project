%% Koeficijent korisnog dejstva
% teorijski max = 0.59, prakticno izmedju 0.25 i 0.45
% 100 slucajnih vrednosti u opsegu 0.25 - 0.45
koeficijent = 0.25 + (0.45 - 0.25) .* rand(100, 1);     

%% Poluprecnik turbine
% 100 slucajnih vrednosti u opsegu 15 - 45 metara
poluprecnik = 15 + (45 - 15) .* rand(100, 1);                        

%% Brzina vetra
% 100 slucajnih vrednosti u opsegu 0.5 - 18 m/s
brzinaVetra = 0.5 + (18 - 0.5) .* rand(100, 1);

%% Gustina vazduha
gustinaVazduha = 1.29;      % uzeto kao konstantna vrednost

%% Povrsina turbine
% dobija se iz poluprecnika
povrsina = poluprecnik .^ 2 .* pi;

%% Snaga
P = 0.5 * gustinaVazduha * koeficijent .* povrsina .* (brzinaVetra .^ 3);
%format long g

%% Grafici
t = 1:4.2:100;            % vreme simulacije, korak 4.2 da bi bilo 24 vrednosti, na svakih sat vremena po jedna

% zavisnost snage od brzine vetra. Vreme simulacije = 1 dan
figure(1)
plot(t, (P(1:24)./1000000), t, brzinaVetra(1:24));
title('Zavisnost snage od brzine vetra');
legend('snaga [MW]', 'brzina vetra [m/s]');
grid on;

% zavisnost snage od precika turbine. Vreme simulacije = 1 dan
figure(2)
plot(t, (P(1:24)./1000), t, (poluprecnik(1:24).*2));     % .*2 jer je precnik
title('Zavisnost snage od precnika turbine');
legend('snaga [kW]', 'precnik [m]');
grid on;