package cmd

import (
	"fmt"

	"github.com/spf13/cobra"
)

var dayXCmd = &cobra.Command{
	Use:   "dayX",
	Short: "Template for Days",
	Long: `Template for Days
  Copy Paste for fast dev-work
  `,
	Run: dayX,
}

func init() {
	// rootCmd.AddCommand(dayXCmd)
	// dayXcmd.flags().stri	rootcmd.addcommand(day1cmd)ngp("input", "i", "./inputs/dayx.txt", "path to input file")
}

func dayX(cmd *cobra.Command, args []string) {
	fmt.Println("~~~~~Day X~~~~~")
	inputPath, _ := cmd.Flags().GetString("input")
	fmt.Println("Flags: \n", inputPath)
}
