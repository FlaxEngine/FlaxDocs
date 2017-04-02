@echo off

if not exist src mkdir src 
cd src

IF EXIST FlaxAPI (

echo Updating Flax API...
cd FlaxAPI
git reset --hard origin/master

git pull origin master
cd ..

) ELSE (

echo Downloading Flax API...
git clone https://github.com/FlaxEngine/FlaxAPI.git

)

echo Source is ready!
cd ..