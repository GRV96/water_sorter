# water_sorter

## Fran�ais

Cette application en ligne de commande r�sout les probl�mes de tri de liquide
(*water sorting puzzles*). Tout d'abord, repr�sentez un probl�me comme dans
les fichiers d'exemple � la racine du d�p�t. Puis, trouvez l'ex�cutable dans
le dossier `/bin` et lancez-le avec les arguments suivants.

**1**: le chemin du fichier qui repr�sente le probl�me.

**2 (optionnel)**: le nombre de solutions trouv�es. Ce nombre sera illimit� si
l'argument est omis ou s'il vaut 0 ou moins. Dans ce cas, l'ex�cution de
l'algorithme sera tr�s longue.

**3 (optionnel)**: le chemin du fichier de sortie, o� les solutions seront
enregistr�es. Si aucun chemin n'est indiqu�, la console affichera les
solutions.

Exemple:

```
.\WaterSorter.exe ...\water_sorter\level5.txt 20 ...\water_sorter\esssai.txt
```

### Repr�sentation des probl�mes

* Un probl�me de tri de liquide comporte plusieurs �prouvettes contenant des
unit�s de liquide de couleurs diff�rentes.

* Dans un fichier texte, �crivez sur une m�me ligne les couleurs contenues
dans chaque �prouvette.

	* Une �prouvette peut contenir quatre unit�s de liquide.

	* Une ligne repr�sente une �prouvette.

	* La premi�re couleur sur une ligne est en haut de l'�prouvette; la
	derni�re couleur est au fond.

	* Dans un probl�me, chaque cha�ne de caract�res correspond � exactement une
	couleur.

	* Les couleurs sont s�par�es par des espaces.

	* Le tiret (`-`) repr�sente une �prouvette vide.

* Les lignes vides sont ignor�es.

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
