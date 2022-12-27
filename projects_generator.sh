#!/bin/bash

destination_directory=$1
solution_name="AoC_"$destination_directory
solution_file=$solution_name".sln"
input_file_name="input.txt"
example_file_name="example.txt"

create_input_file() {
  touch $input_file_name
  touch $example_file_name
}

overwrite_program_file() {
  echo "var inputFile = \"$input_file_name\";

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
    <None Include=\"$input_file_name\">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>

  <ItemGroup>
    <None Include=\"$example_file_name\">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>" >$1".csproj"
}

create_solution_file() {
  pushd $destination_directory
  if [ ! -f "$solution_file" ]; then
    dotnet new sln -n $solution_name
  else
    echo "Solution file '$solution_file' already exists."
  fi
  popd
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
  project_name="DAY_"$1"_$2"
  project_file=$project_name".csproj"
  if [ ! -d "$project_name" ]; then
    dotnet new console -n $project_name
    pushd $project_name
    create_input_file
    overwrite_program_file
    overwrite_csproj_file $project_name
    popd
  else
    echo "Project's directory '$project_name' already exists."
  fi
  dotnet sln add $project_name/$project_file
}

for day in {01..25}; do
  create_destination_directory $destination_directory
  create_solution_file $destination_directory
  pushd $destination_directory
  generate_project $day 1
  generate_project $day 2
  popd
done
