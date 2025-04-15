package cmd

import (
	"bufio"
	"fmt"
	"os"
	"slices"
	"strconv"

	"github.com/spf13/cobra"
)

var day1Cmd = &cobra.Command{
	Use:   "day1",
	Short: "Template for Days",
	Long: `Template for Days
  Copy Paste for fast dev-work
  `,
	Run: day1,
}

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func init() {
	rootCmd.AddCommand(day1Cmd)
	day1Cmd.Flags().StringP("input", "i", "./inputs/day1.txt", "Path to input file")
}

func day1(cmd *cobra.Command, args []string) {
	fmt.Println("~~~~~Day 1~~~~~")
	inputPath, _ := cmd.Flags().GetString("input")
	fmt.Println("Flags: \n", inputPath)

	inputFile, err := os.Open(inputPath)
	check(err)
	scanner := bufio.NewScanner(inputFile)

	counter := 0
	valueCache := []int{}
	isFirstDuplicate := true
	isFirstLap := true

	var lines []string
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}

	for isFirstDuplicate {
		for _, line := range lines {
			value, err := strconv.Atoi(line)
			check(err)
			counter += value
			if slices.Contains(valueCache, counter) && isFirstDuplicate {
				fmt.Println("Part 2: ", counter)
				isFirstDuplicate = false
			}
			valueCache = append(valueCache, counter)
		}
		if isFirstLap {
			fmt.Println("Part 1: ", counter)
			isFirstLap = false
		}
	}

}
