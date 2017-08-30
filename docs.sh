#!/bin/sh

#todo: finish find_screen func to work well

find_screen() {
	if screen -ls "$1" | grep -o "^\s*[0-9]*\.$1[ "$'\t'"](" --color=NEVER -m 1 | grep -oh "[0-9]*\.$1" --color=NEVER -m 1 -q >/dev/null; then
		screen -ls "$1" | grep -o "^\s*[0-9]*\.$1[ "$'\t'"](" --color=NEVER -m 1 | grep -oh "[0-9]*\.$1" --color=NEVER -m 1 2>/dev/null
		return 0
	else
		return 1
	fi
}

isRunning() {
	#if  screen -list | grep -q "flaxdocs"; then
	if find_screen flaxdocs >/dev/null; then
		return 1
	else
		return 0
	fi
}

start() {
	#if  isRunning; then
	#	echo 'Service already running'
	#	return 1
	#fi
	echo 'Starting service...'
	screen -d -m -S "flaxdocs" ./serve.sh
	
	#if isRunning; then
		echo 'Service started'
	#else
	#	echo 'Cannot start service'
	#	return 1
	#fi
}

stop() {
	#if ! isRunning; then
	#	echo 'Service not running'
	#	return 1
	#fi
	echo 'Stopping service...'
	screen -X -S flaxdocs quit
	echo 'Service stopped'
}

status() {
	if  isRunning; then
		echo 'Service is running'
	else
		echo 'Service not running'
	fi
}

update_api() {
	mkdir -p src
	cd src
	
	if [ -d "FlaxAPI" ]; then
		echo "Updating Flax API..."
		cd FlaxAPI
		git reset --hard origin/master
		git pull origin master
		cd ..
	else
		echo "Downloading Flax API..."
		git clone https://github.com/FlaxEngine/FlaxAPI.git
	fi

	echo "Source is ready!"
	cd ..
}

update() {
	echo "Updating Flax Docs..."
	git reset --hard origin/master
	git pull origin master
	
	chmod +x docs.sh
	chmod +x serve.sh
	
	update_api
}

build() {
	echo "Preparing API metadata..."
	mono docfx/docfx.exe metadata
	
	echo "Building site..."
	mono docfx/docfx.exe build
	cp favicon.ico _site/favicon.ico
	
	echo "Done!"
}

# Enter docs root directory
cd "$(dirname "$0")"

# Switch command
case "$1" in
	start)
		start
	;;
	stop)
		stop
	;;
	status)
		status
	;;
	restart)
		stop
		start
	;;
	build)
		build
	;;
	update)
		update
	;;
	refresh)
		
		# Optional refresh
		./docs.sh stop
		./docs.sh update
		rm -rf _site
		rm -rf api
		unzip -o Docs.zip
		./docs.sh start
		
		#stop
		#update
		#build
		#start
	;;
	*)
		echo "Usage: $0 {start|stop|status|restart|build|update|refresh}"
esac

exit 0