package cmd

import (
	"bufio"
	"fmt"
	"os"
	"regexp"
	"strconv"

	"github.com/spf13/cobra"
)

var day3Cmd = &cobra.Command{
	Use:   "day3",
	Short: "day3",
	Long:  `day3`,
	Run:   day3,
}

func init() {
	rootCmd.AddCommand(day3Cmd)
	day3Cmd.Flags().StringP("input", "i", "./inputs/day3.txt", "path to input file")
}

func day3(cmd *cobra.Command, args []string) {
	fmt.Println("~~~~~Day 3~~~~~")
	inputPath, _ := cmd.Flags().GetString("input")
	fmt.Println("Flags: \n", inputPath)

	inputFile, err := os.Open(inputPath)
	scanner := bufio.NewScanner(inputFile)
	check(err)

	var lines []string
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}

	//Part 1
	type fabricCut struct {
		ID         int
		Coordinate []int
		Size       []int
	}
	fabricArea := [1000][1000]int{}
	var cuts []fabricCut
	for _, line := range lines {
		rId, _ := regexp.Compile(`#(\d+)\s@\s(\d+),(\d+):\s(\d+)x(\d+)`)
		matches := rId.FindAllStringSubmatch(line, -1)
		if len(matches) > 0 {
			groups := matches[0][1:]
			nums := make([]int, len(groups))
			for i, s := range groups {
				n, _ := strconv.Atoi(s)
				nums[i] = n
			}
			cut := fabricCut{
				ID:         nums[0],
				Coordinate: nums[1:3],
				Size:       nums[3:5],
			}
			cuts = append(cuts, cut)
		}
	}
	for _, cut := range cuts {
		for x := 0; x < cut.Size[0]; x++ {
			for y := 0; y < cut.Size[1]; y++ {
				fabricArea[cut.Coordinate[0]+x][cut.Coordinate[1]+y] += 1
			}
		}
	}
	counter := 0
	for xfi, xFabric := range fabricArea {
		for yfi, _ := range xFabric {
			if fabricArea[xfi][yfi] >= 2 {
				counter++
			}
		}
	}
	fmt.Println(counter)
}
