package cmd

import (
	"bufio"
	"fmt"
	"os"

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

	for li, line := range lines {

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
		foundString := false
		matches := make([]string, len(lines))
		type DiffMatch struct {
			Line      string
			DiffIndex int
			DiffChar  rune
		}
		fMatches := []DiffMatch{}
		for ci, _ := range line {
			for _, cline := range lines[li:] {
				if cline[ci] == line[ci] {
					matches[li] = cline
				} else {
					diff := map[int]string{}
					diff[ci] = string(cline)
					fMatches = append(fMatches, DiffMatch{
						Line:      cline,
						DiffIndex: ci,
						DiffChar:  rune(cline[ci]),
					})
				}
				// foreach fMatch ignore at diffIndex and compare the rest
				for _, fMatch := range fMatches {
					if line[:fMatch.DiffIndex]+line[fMatch.DiffIndex+1:] == fMatch.Line[:fMatch.DiffIndex]+fMatch.Line[fMatch.DiffIndex+1:] {
						fmt.Println("Part 2: ", fMatch.Line[:fMatch.DiffIndex]+fMatch.Line[fMatch.DiffIndex+1:])
						foundString = true
					}
					if foundString {
						return
					}
				}
			}
		}

	}

	fmt.Println("Part 1: ", lineValues[2]*lineValues[3])
}
