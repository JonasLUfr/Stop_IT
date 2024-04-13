# Projet de Lifprojet SA1 jeu de stratégie

Ce projet <Stop_it> a été réalisé par Runnian Lu  et Yifan Xiang. Les détails du code sont sur GitHub:https://github.com/JonasLUfr/Stop_IT

Stop_it est un jeu de stratégie de type "Tower Defense" developpé en c# en utilisant le moteur Unity. Ce projet de developpement à été réalisé dans le cadre de l'UE LIFPROJET avec M.Samir AKNINE
Voir la page du cours 2023/2024 Printemps :  http://cazabetremy.fr/wiki/doku.php?id=projet:sujets

Ce dossier contient un fichier exécutable Stop_IT.exe permettant d'executer le jeu-vidéo.

## Utilisation sur toutes OS
- Cliquez ici pour télécharger le jeu complet: https://drive.google.com/file/d/1i1pFopLjs52Y9AIESPTx3ecAoZfagU_D/view?usp=sharing
- Cliquez ici pour voir le demo-video: https://drive.google.com/file/d/1-RzR0tMRhdlzQXq8LtSYb8nhlcnAYr7V/view?usp=sharing

 ### Sous Linux
 - Ce système ne supporte pas actuellement . 

 ### Sous macOS
 - Après avoir extrait le dossier, il suffit de cliquer sur le fichier exécutable stop_it.exe pour ouvrir le jeu.
 - Remarque : Veillez à mettre à jour la version la plus récente de macOS.

 ### Sous Windows
 - Il est fortement recommandé de faire tourner ce jeu avec le système d'exploitation Windows.
 - Ce jeu est compatible avec Windows 7 et les versions supérieures du système d'exploitation.

## Description du jeu :
- Dans ce jeu, les joueurs auront la possibilité de placer différentes tours le long de ce chemin pour attaquer les ennemis et les empêcher d'atteindre leur destination. La victoire est obtenue si les ennemis sont arrêtés par les tours avant d'atteindre leur destination. Si les ennemis parviennent à atteindre leur point d'arrivée, c'est un échec pour le joueur.
- Remarque : l'installation et la mise à niveau de chaque tourelle coûtent de l'argent. Donc veuillez choisir avec prudence le nombre et l'emplacement des tourelles !

## Contrôles&Tutoriels
- Utilisez la molette de la souris pour contrôler la hauteur du point de vue.
- Utilisez les touches w, a, s, d du clavier pour contrôler la vue vers le haut, le bas, la gauche et la droite pour vous déplacer.
- Cliquez sur les carrés blancs de la carte pour placer les tourelles.
- En cliquant à nouveau sur une tourelle déja installée, il est possible de la détruire et de l'améliorer.

## Codes ou debug
- Tout le code est téléchargé sur GitHub : https://github.com/JonasLUfr/Stop_IT
- Mais pour déboguer le code, vous devez utiliser le moteur Unity.
- Cliquez ici pour télécharger le moteur Unity : https://unity.com/fr/download
- Importez ensuite l'ensemble de notre code.
- Ou contactez l'auteur à l'adresse runnian.lu@etu.univ-lyon1.fr ou Yifan.Xiang@etu.univ-lyon1.fr pour ils vous ajouteront à l'équipe de développement.

## Les principes pour chaque script
Les fichiers de code de script du jeu se trouvent à l'adresse PATH : Assets/script
- BuildManager:
Ce gestionnaire est au cœur du jeu de défense de tour, gérant l'interaction entre les joueurs et le monde du jeu, ainsi que la gestion des ressources du jeu et des objets du jeu.

- GameManager:
Ce script permet donc de gérer les conditions de victoire et d'échec du jeu, ainsi que les transitions entre les différentes phases du jeu (rejouer, revenir au menu principal).

- GameMenu:
Ce script est utilisé pour contrôler les actions de départ et de sortie du jeu depuis un menu principal.

- MapCube:
ce script gère la construction, l'amélioration et la destruction de tourelles sur les cubes de la carte, ainsi que le changement de couleur visuel des cubes lorsque la souris entre et sort de leur zone.

- ViewController:
Ce script permet donc au joueur de déplacer la caméra dans le jeu en utilisant les touches du clavier et la molette de la souris.

- WayPoints:
Ce script permet donc de centraliser et de stocker les positions des points de passage dans un chemin, ce qui est utile pour les systèmes de déplacement des ennemis, par exemple, dans un jeu de défense de tour. Les autres scripts peuvent accéder à ce tableau statique pour obtenir les positions des waypoints sans avoir à rechercher les objets individuels dans la scène.

- EnemyController:
ce script gère le mouvement, la vie et la destruction des ennemis dans le jeu, ainsi que la gestion des effets visuels et du compteur d'ennemis vivants.

- EnemySpawner:
 ce script gère la génération des vagues d'ennemis dans le jeu, en attendant que tous les ennemis d'une vague soient détruits avant de passer à la vague suivante, et en déclenchant la victoire du joueur une fois que toutes les vagues ont été vaincues.

- EnemyWave:
 Cette classe est utilisée par le script "EnemySpawner" pour définir les différentes vagues d'ennemis à générer dans le jeu. Chaque instance de cette classe représente une vague d'ennemis avec ses propres caractéristiques, telles que le type d'ennemi, le nombre et la fréquence de génération

- Turret:
 Ce script permet donc de créer des tourelles qui peuvent détecter et attaquer les ennemis à portée, offrant ainsi une mécanique de jeu intéressante dans un jeu de défense de tour.

- TurretData:
 Cette classe est utilisée par d'autres scripts, tels que le gestionnaire de construction de tourelles, pour accéder aux informations sur chaque type de tourelle, ce qui facilite la configuration et la gestion des tourelles dans le jeu.
- Bullets:
Ce script est utilisé par les tourelles pour tirer des projectiles sur les ennemis détectés, ce qui contribue à la mécanique de combat du jeu.


## Licence
Ce projet est sous licence Runnian LU et Yifan Xiang.
