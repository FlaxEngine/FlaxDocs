#!/bin/bash
echo "Starting Flax Documentation..."
mono docfx/docfx.exe serve _site -p 8080
echo "End."