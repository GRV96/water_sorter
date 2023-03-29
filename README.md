# water_sorter

## Français

Cette application en ligne de commande résout les problèmes de tri de liquide
(*water sorting puzzles*). Tout d'abord, représentez un problème comme dans
les fichiers d'exemple à la racine du dépôt. Puis, trouvez l'exécutable dans
le dossier `/bin` et lancez-le avec les arguments suivants.

**1**: le chemin du fichier qui représente le problème.

**2 (optionnel)**: le nombre de solutions trouvées. Ce nombre sera illimité si
l'argument est omis ou s'il vaut 0 ou moins. Dans ce cas, l'exécution de
l'algorithme sera très longue.

**3 (optionnel)**: le chemin du fichier de sortie, où les solutions seront
enregistrées. Si aucun chemin n'est indiqué, la console affichera les
solutions.

Exemple:

```
.\WaterSorter.exe ...\water_sorter\level5.txt 20 ...\water_sorter\esssai.txt
```

### Représentation des problèmes

* Un problème de tri de liquide comporte plusieurs éprouvettes contenant des
unités de liquide de couleurs différentes.

* Dans un fichier texte, écrivez sur une même ligne les couleurs contenues
dans chaque éprouvette.

	* Une éprouvette peut contenir quatre unités de liquide.

	* Une ligne représente une éprouvette.

	* La première couleur sur une ligne est en haut de l'éprouvette; la
	dernière couleur est au fond.

	* Dans un problème, chaque chaîne de caractères correspond à exactement une
	couleur.

	* Les couleurs sont séparées par des espaces.

	* Le tiret (`-`) représente une éprouvette vide.

* Les lignes vides sont ignorées.

* Les commentaires commencent par `#`.

[Source](https://www.silvergames.com/en/water-sort) de l'image du niveau 5

## English

This command line application solves water sorting puzzles. First, represent a
puzzle as in the example files at the repository's root. Then, find the
executable in the `/bin` folder and run it with the following arguments.

**1**: the path to the file that represents the puzzle.

**2 (optional)**: the number of solutions found. This number will be unlimited
if the argument is omitted or less than or equal to 0. In that case, the
algorithm's execution will be very long.

**3 (optional)**: the path to the output file, where the solutions will be
recorded. If no path is provided, the console will display the solutions.

Example:

```
.\WaterSorter.exe ...\water_sorter\level5.txt 20 ...\water_sorter\test.txt
```

### Puzzle Representation

* A water sorting puzzle consists in several test tubes containing liquid units
of different colors.

* In a text file, write the colors contained in each test tube on the same
line.

	* A test tube can contain four liquid units.

	* A line represents one test tube.

	* The first color on a line is at the top of a test tube; the last color is
	at the bottom.

	* In a puzzle, each character string corresponds to exactly one color.

	* The colors are separated by spaces.

	* Hyphens (`-`) represent an empty test tube.

* Empty lines are ignored.

* Comments start with `#`.

[Source](https://www.silvergames.com/en/water-sort) of the level 5 picture
