#################################################################################
#																				#
#   _____    ____    _______   ______   ______       _   _   _                  #
#  / ____|  / __ \  |__   __| |  ____| |  ____|     | | (_) | |                 #
# | (___   | |  | |    | |    | |__    | |__      __| |  _  | |_    ___    _ __ #
#  \___ \  | |  | |    | |    |  __|   |  __|    / _` | | | | __|  / _ \  | '__|#
#  ____) | | |__| |    | |    | |      | |____  | (_| | | | | |_  | (_) | | |   #
# |_____/   \____/     |_|    |_|      |______|  \__,_| |_|  \__|  \___/  |_|   #
#                                                                               #
#																				#
#################################################################################
SaveGame Editor Tool for "Sons Of The Forest"
Created by TheSkimek
#################################################################################

Warning: 
ALWAYS Backup your save files before trying to change anything with or without this tool!

This tool can help you change some save files without having to go through the files yourself,
find the correct location and what to change.

Current functions include:
- Create Backup of save files
- Change your inventory (also works with items you didnt have in your inventory yet)
- Give all currently available items into inventory (amount is set to 100)
- Remove all items
- Change all armor to whatever you selected (armor points will be set to 9999)
- Change specific armor slot to selected armor
- Change armor points to specified value
- Remove all blueprints in world
- Set all blueprints in world to "almost complete" (will set "added amount" to the required amount of the blueprint -1)
- Remove specific blueprints
- Set amount of added items to specific blueprint
- Change blueprints to other blueprint. Tries to keep the "added amount" of the previous blueprint if possible

If there are still items missing in the item list, there is a "ItemIDList.csv" file in the "data" folder, where you can add any ItemId yourself.
It does NOT work with items that are not (yet) in the game, like for example the rifle. Unreleased items that are added like this, will be
automatically deleted from the file by the game.

Same goes for the blueprint information, which can be found in the "data" folder as "structureInfo.json".
Change the files on your own risk, as duplicate IDs or wrong syntax will break the tool.

I plan on adding some further functionality, but as this is just a little freetime sideproject, i dont promise anything.