
<img width="567" height="493" alt="image" src="https://github.com/user-attachments/assets/110143a9-6c11-4501-b469-bd0ce08d43ca" />





<img width="580" height="532" alt="image" src="https://github.com/user-attachments/assets/6514c8a4-1d83-4efc-8bed-a83984a177bc" />






# Flappy Bird (Unity)

Un clone amélioré de Flappy Bird développé sous Unity, avec gestion de score, obstacles dynamiques (pipes), objets bonus (Core Flames), changement de bande-son, et logique de désactivation temporaire des collisions.
( Ce répository ne contient que les script Csharp utilisé pour le jeu , les Assets graphique n'y sont pas disponibles )

## Prérequis

- Unity (version LTS recommandée)
- .NET Framework 4.7.1 (cible du projet)
- Git (optionnel, pour versionner)

## Fonctionnalités

- Système de score (`LogicManagerScript`): score joueur et score de flammes.
- Spawner de tuyaux et Core Flames (`PipeSpawnScript`): génération régulière, position aléatoire contrôlée, désactivation globale pendant une durée.
- Mouvement des tuyaux (`PipeMoveScript`): déplacement horizontal et auto-destruction hors écran.
- Trigger de score sur passage entre tuyaux (`PipeTriggerScript`).
- Désactivation / réactivation des colliders des tuyaux (`PipeDesactivateScript`).
- Gestion audio (`audioManagerScript`): OST par défaut, switch temporaire pendant les effets, arrêt sur Game Over.
- Gestion de scène / restart (`LogicManagerScript.restartGame`).

## Structure des scripts (principaux)

- `Assets/Script/BirdScript.cs`: contrôle de l’oiseau (impulsion verticale, état de vie).
- `Assets/Script/LogicManagerScript.cs`: score, UI, Game Over, progression de vitesse.
- `Assets/Script/PipeSpawnScript.cs`: spawn des tuyaux et Core Flames, gestion état global (désactivationcolliders, timer).
- `Assets/Script/PipeMoveScript.cs`: déplacement et nettoyage des tuyaux.
- `Assets/Script/PipeTriggerScript.cs`: incrémentation du score à la traversée.
- `Assets/Script/PipeManagementScript.cs` (`PipeDesactivateScript`): (dé)activation des colliders top/bottom des tuyaux.
- `Assets/Script/audioManagerScript.cs`: gestion de la musique et des effets.
- `Assets/Script/coreFlameMoveScript.cs`: mouvement/logic des Core Flames (si applicable).
- Autres scripts utilitaires: background, particules, scènes, etc.

## Logique de désactivation des tuyaux

- Accumulez des Core Flames (`flameScore`).
- À partir d’un seuil (ex: 3), `PipeSpawnScript`:
- Active `isPipeColliderDeactivated` pour `deactivationDuration`.
- Désactive les colliders des tuyaux existants via `PipeDesactivateScript.DeactivateColliderPipe()`.
- Les nouveaux tuyaux spawnés pendant la fenêtre sont désactivés automatiquement.
- Réinitialise le `flameScore`.
- Prolonge la durée si le seuil est atteint à nouveau pendant l’effet.

## Bonnes pratiques Git

- Commits centrés sur les scripts:
- Ajouter uniquement `Assets/Script/*.cs`.
- Utiliser un `.gitignore` Unity pour ignorer:
- `Library/`, `Temp/`, `UserSettings/`, `.vs/`, `*.csproj`, `*.sln`, etc.

## Crédits

- Unity Technologies pour le moteur de jeu.
