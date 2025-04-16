package cmd

import (
	"bufio"
	"fmt"
	"os"

	"github.com/spf13/cobra"
)

var dayXCmd = &cobra.Command{
	Use:   "dayX",
	Short: "dayX",
	Long:  `dayX`,
	Run:   dayX,
}

func init() {
	// rootCmd.AddCommand(dayXCmd)
	//dayXCmd.Flags().StringP("input", "i", "./inputs/dayX.txt", "path to input file")
}

func dayX(cmd *cobra.Command, args []string) {
	fmt.Println("~~~~~Day X~~~~~")
	inputPath, _ := cmd.Flags().GetString("input")
	fmt.Println("Flags: \n", inputPath)
	inputFile, err := os.Open(inputPath)
	check(err)
	scanner := bufio.NewScanner(inputFile)

	var lines []string
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}

	// for _, line := range lines {
	// }
}
