# ThunderBugs
Foosball app

TRELLO BOARD: https://trello.com/b/1TrExE5d/to-do

# PREPARATION
1. EmguCV Download: https://sourceforge.net/projects/emgucv/files/emgucv/3.2/libemgucv-windesktop-3.2.0.2682.exe/download
2. Install it
3. Go to: C:\Emgu\emgucv-windesktop 3.2.0.2682\bin\x86 and copy your PATH
4. System > Advanced System Settings > Enviroment Variables > Add new PATH > PASTE the path: C:\Emgu\emgucv-windesktop 3.2.0.2682\bin\x86

# Run the project

1. Go to project: Foosball
2. Project > add reference > Browse > Select all dll files and just only one debbuger (if you use VS Community 2017 choose: Emgu.CV.DebuggerVisualizers.VS2017.dll )
3. Project > Add Existing item... > Go to: C:\Emgu\emgucv-windesktop 3.2.0.2682\bin\x86 and choose all .dll.
4. Run the project!

# Video show preparation and other stuff

https://www.youtube.com/watch?v=7iyfJ-YaKvw&t=130s

Look from: (1:50) till: (7:35)
All this video was based what I done.

# Git stuff
To change branch: git checkout (branch name). For exemple master|dev

To create new branch: git checkout -b (branch name).

OTHER USEFUL COMMANDS:

1. git add . | directory name | file name
2. git commit -m "Initial commit"
3. git status
4. git push (remote name) (branch name) - exemple: git push origin master
5. git remote -v -check your remote
6. git remote add (branch name) (remote) - add new remote
7. git remote set-url (branch name) (remote) - change to new one remote
8. git init - to make new git directory (this directory is invisible)
9. git pull - get newest version
