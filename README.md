# water_sorter

## Fran�ais

Cette application en ligne de commande r�sout les probl�mes de tri de liquide
(*water sorting puzzles*). Tout d'abord, repr�sentez un probl�me comme dans
les fichiers d'exemple � la racine du d�p�t. Puis, trouvez l'ex�cutable dans
le dossier `/bin` et lancez-le avec les arguments suivants.

**1**: le chemin du fichier qui repr�sente le probl�me.

**2 (optionnel)**: le nombre maximal de solutions � trouver. Ce nombre sera
illimit� si l'argument est omis ou s'il vaut 0 ou moins. Dans ce cas,
l'ex�cution de l'algorithme sera tr�s longue.

**3 (optionnel)**: le chemin du fichier de sortie, o� les solutions seront
�crites. Si aucun chemin n'est indiqu�, la console affichera les solutions.

Exemple:

```
.\WaterSorter.exe ...\water_sorter\level5.txt 20 ...\water_sorter\esssai.txt
```

[Source](https://www.silvergames.com/en/water-sort) de l'image du niveau 5

### Ordre des �prouvettes

L'application ordonne les �prouvettes de gauche � droite, de haut en bas. Elle
leur attribue un indice commen�ant � 0 comme l'illustre l'image du niveau 5.

### Repr�sentation des probl�mes

* Un probl�me de tri de liquide comporte plusieurs �prouvettes contenant des
unit�s de liquide de couleurs diff�rentes.

* Dans un fichier texte, �crivez sur une m�me ligne les couleurs contenues
dans chaque �prouvette.

	* L'ordre des �prouvettes doit �tre le m�me dans le probl�me et sa
	repr�sentation.

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

### Solutions

Une solution est une s�rie de versements de liquide d'une �prouvette � une
autre arp�s lesquels toutes les unit�s de liquide de m�me couleur sont dans la
m�me �prouvette. Les instructions de versement identifient les �prouvettes par
leur indice.

## English

This command line application solves water sorting puzzles. First, represent a
puzzle as in the example files at the repository's root. Then, find the
executable in the `/bin` folder and run it with the following arguments.

**1**: the path to the file that represents the puzzle.

**2 (optional)**: the maximal number of solutions to find. This number will be
unlimited if the argument is omitted or less than or equal to 0. In that case,
the algorithm's execution will be very long.

**3 (optional)**: the path to the output file, where the solutions will be
written. If no path is provided, the console will display the solutions.

Example:

```
.\WaterSorter.exe ...\water_sorter\level5.txt 20 ...\water_sorter\test.txt
```

[Source](https://www.silvergames.com/en/water-sort) of the level 5 picture

### Test Tube Order

The application orders the test tubes from left to right, from top to bottom.
It assigns them indices starting at 0 as shown in the level 5 picture.

### Puzzle Representation

* A water sorting puzzle consists in several test tubes containing liquid units
of different colors.

* In a text file, write the colors contained in each test tube on the same
line.

	* The test tube order in the text file must be the same as in the puzzle.

	* A test tube can contain four liquid units.

	* A line represents one test tube.

	* The first color on a line is at the top of a test tube; the last color is
	at the bottom.

	* In a puzzle, each character string corresponds to exactly one color.

	* The colors are separated by spaces.

	* A hyphen (`-`) represents an empty test tube.

* Empty lines are ignored.

* Comments start with `#`.

### Solutions

A solution is a series of pourings from a test tube to another resulting in all
liquid units of the same color being in the same tube. The pouring instructions
identify the test tubes by their index.
