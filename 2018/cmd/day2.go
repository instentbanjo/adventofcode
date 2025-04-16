package cmd

import (
	"bufio"
	"fmt"
	"os"
	"regexp"

	"github.com/spf13/cobra"
)

var day2Cmd = &cobra.Command{
	Use:   "day2",
	Short: "day2",
	Long:  `day2`,
	Run:   day2,
}

func init() {
	rootCmd.AddCommand(day2Cmd)
	day2Cmd.Flags().StringP("input", "i", "./inputs/day2.txt", "Path to input file")
}

func day2(cmd *cobra.Command, args []string) {
	fmt.Println("~~~~~Day 2~~~~~")
	inputPath, _ := cmd.Flags().GetString("input")
	fmt.Println("Flags: \n", inputPath)

	inputFile, err := os.Open(inputPath)
	check(err)
	scanner := bufio.NewScanner(inputFile)

	var lines []string
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}

	lineValues := make(map[int]int)

	for _, line := range lines {

		// Part 1
		hasFoundDouble := false
		hasFoundTripple := false
		freq := make(map[rune]int)
		for _, r := range line {
			freq[r]++
		}
		for i, _ := range freq {
			if freq[i] == 2 && !hasFoundDouble {
				lineValues[2]++
				hasFoundDouble = true
			}
			if freq[i] == 3 && !hasFoundTripple {
				lineValues[3]++
				hasFoundTripple = true
			}
		}

		// Part 2
		for i, c := range line {
			// See if any match the currentMatch, if not, add wildcard and go to next char, if still not, continue
			r, _ := regexp.Compile("^" + line[:i] + "." + line[i+1:] + "$")
			for _, line := range lines {
				if r.MatchString(line) {
					fmt.Println(line)
					fmt.Println(string(c))
				}
			}
		}

	}

	fmt.Println("Part 1: ", lineValues[2]*lineValues[3])
}
