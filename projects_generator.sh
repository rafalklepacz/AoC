#!/bin/bash

create_input_file() {
  touch input.txt
}

overwrite_program_file() {
  echo "var inputFile = \"input.txt\";

var result = File.ReadAllLines(inputFile)
                 .AsEnumerable();

Console.WriteLine();" >Program.cs
}

overwrite_csproj_file() {
  echo "<Project Sdk=\"Microsoft.NET.Sdk\">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <None Include=\"input.txt\">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>" >$1".csproj"
}

create_destination_directory() {
  if [ ! -d "$1" ]; then
    mkdir $1
    pushd $1
    echo "{
  \"sdk\": {
    \"version\": \"6.0.100\",
    \"rollForward\": \"latestFeature\"
  }
}" >global.json
    popd
  else
    echo "Destination directory '$1' already exists."
  fi
}

generate_project() {
  if [ ! -d "$1" ]; then
    dotnet new console -n $1
    pushd $1
    create_input_file
    overwrite_program_file
    overwrite_csproj_file $1
    popd
  else
    echo "Project's directory '$1' already exists."
  fi
}

for day in {01..25}; do
  create_destination_directory $1
  pushd $1
  generate_project "DAY_"$day"_1"
  generate_project "DAY_"$day"_2"
  popd
done
